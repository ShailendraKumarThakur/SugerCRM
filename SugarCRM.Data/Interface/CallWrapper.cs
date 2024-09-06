using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using static SugarCRM.Constants;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using SugarCRM.Data.IPaaSApi.Model;
using Integration.Abstract.Model;

namespace SugarCRM.Data.Interface
{
    [DataContract]
    public class CallWrapper : Integration.Abstract.CallWrapper
    {
        [DataMember]
        public RestClient _sugarCRMClient;
        public Connection _SugarCRMConnection;
        public Settings _SugarCRMSettings;


        [DataMember]
        private DateTime lastRestRequestCreateDT; // We use this to determine the total time taken for a given request. We log the DT when a rest request is made (the first step of each
                                                  // wrapped call) and then find the difference in the ResponseHandler.
        [DataMember]
        private bool _connected = false;
        public override bool Connected { get { return _connected; } }

        [DataMember]
        private string _connectionMessage;
        internal Connection _integrationConnection;

        public override string ConnectionMessage { get { return _connectionMessage; } }

        public CallWrapper() { }

        public async Task EstablishConnection(Integration.Abstract.Connection connection, Integration.Abstract.Settings settings)
        {
            _SugarCRMSettings = (Settings)settings;
            _SugarCRMConnection = (Connection)connection;

            //_sugarCRMClient = new RestClient();
            //_sugarCRMClient.AddDefaultHeader();
            //_sugarCRMClient.AddDefaultHeader();
            //_sugarCRMClient.AddDefaultHeader();
            //var restResponse = await _sugarCRMClient.Execute();


            //_sugarCRMClient.UseSerializer(() => new Utilities.RestSharpNewtonsoftSerializer());

            //TokenResponse

            try
            {
                PersistentData persistentDataAuthToken = _SugarCRMSettings.PersistentData.GetValue("AuthToken");
                PersistentData persistentDataRefreshToken = _SugarCRMSettings.PersistentData.GetValue("RefreshToken");

                if (persistentDataAuthToken == null || persistentDataRefreshToken == null || (persistentDataRefreshToken != null && persistentDataRefreshToken.ExpirationDateTime <= DateTime.Now))
                {
                    GetToken(_SugarCRMSettings);
                }
                
                if (persistentDataAuthToken != null && persistentDataAuthToken?.ExpirationDateTime <= DateTime.Now)
                {
                    RefreshToken(_SugarCRMSettings);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



            string ValidationResponse = await ValidateConnection();

            if (ValidationResponse != "Success")
            {
                _connectionMessage = ValidationResponse;
                throw new Exception(ValidationResponse);
            }
            else
            {
                _connected = true;
            }
        }

        public bool GetToken(Settings _SugarCRMSettings)
        {
            string baseURL = string.Format("https://{0}/oauth2", _SugarCRMSettings.Url);
            _sugarCRMClient = new RestClient(baseURL);

            RestRequest refreshTokenRequest = new RestRequest(string.Format("/token?grant_type=password&client_id=sugar&username={0}&password={1}&platform=base&Content-Type=application/json", _SugarCRMSettings.APIUser, _SugarCRMSettings.APIPassword), Method.Post);
            refreshTokenRequest.AddHeader("Content-Type", "application/json");
            refreshTokenRequest.AddHeader("Cache-Control", "no-cache");
            refreshTokenRequest.AddHeader("Accept", "application/json");
            RestResponse resp = (RestSharp.RestResponse)_sugarCRMClient.Execute(refreshTokenRequest);
            if (resp.StatusCode != System.Net.HttpStatusCode.OK || resp.Content == null)
            {
                Console.WriteLine("Refresh Token could not be obtained, process terminating");
                return false;
            }

            Token token = (Token)JsonConvert.DeserializeObject(resp.Content, typeof(Token));

            _SugarCRMSettings.PersistentData.SaveValue("AuthToken", token.access_token, DateTime.Now.AddSeconds(token.expires_in));
            _SugarCRMSettings.PersistentData.SaveValue("RefreshToken", token.refresh_token, DateTime.Now.AddSeconds(token.refresh_expires_in));
            return true;
        }

        public bool RefreshToken(Settings _SugarCRMSettings)
        {
            string baseURL = string.Format("https://{0}/oauth2", _SugarCRMSettings.Url);
            _sugarCRMClient = new RestClient(baseURL);

            RestRequest refreshTokenRequest = new RestRequest(string.Format("/token?grant_type=refresh_token&client_id=sugar&platform=base&Content-Type=application/json&refresh_token={0}", _SugarCRMSettings.PersistentData.GetValue("RefreshToken")), Method.Post);
            refreshTokenRequest.AddHeader("Content-Type", "application/json");
            refreshTokenRequest.AddHeader("Cache-Control", "no-cache");
            refreshTokenRequest.AddHeader("Accept", "application/json");
            RestResponse resp = (RestSharp.RestResponse)_sugarCRMClient.Execute(refreshTokenRequest);
            if (resp.StatusCode != System.Net.HttpStatusCode.OK || resp.Content == null)
            {
                Console.WriteLine("Refresh Token could not be obtained, process terminating");
                return false;
            }

            Token token = (Token)JsonConvert.DeserializeObject(resp.Content, typeof(Token));

            _SugarCRMSettings.PersistentData.SaveValue("AuthToken", token.access_token, DateTime.Now.AddSeconds(token.expires_in));
            _SugarCRMSettings.PersistentData.SaveValue("RefreshToken", token.refresh_token, DateTime.Now.AddSeconds(token.refresh_expires_in));
            return true;

        }

        // This is just a short function to simplify the clapback registration calls. Every call from this class will have the same externalsystemid and direction.
        public void RegisterClapbackCall(int MappingCollectionType, object id)
        {
            // If there is no connection (e.g. we are running this from the Test project), skip this step.
            if (_SugarCRMConnection == null)
                return;

            _SugarCRMConnection.ClapbackTrackerFunctionAsync(_SugarCRMConnection.ExternalSystemId, (int)MappingCollectionType, Convert.ToString(id), (int)TM_MappingDirection.FROM_IPAAS);
        }

        public async Task<string> ValidateConnection()
        {
            string baseURL = string.Format("https://{0}", _SugarCRMSettings.Url);
            _sugarCRMClient = new RestClient(baseURL);
            //To test connectivity, we just request Helloworld or some lightweight equivalent end-point from the 3rd party API.
            RestSharp.RestRequest req = new RestSharp.RestRequest(string.Format("/Accounts", _SugarCRMSettings.Url), Method.Get);
            req.AddHeader("Authorization", string.Format("Bearer {0}", _SugarCRMSettings.PersistentData.GetValue("AuthToken").Value));
            RestResponse resp = (RestResponse)await _sugarCRMClient.ExecuteAsync(req);

            string ResponseVal = "";
            if (resp.ErrorException != null)
            {
                ResponseVal = resp.ErrorException.Message;
            }
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ResponseVal = resp.Content;
            }
            else
            {
                return "Success";
            }

            return "Unknown Issue Executing ValidateConnection";
        }
    }
}