using Integration.Abstract.Helpers;
using Integration.Abstract.Model;
using Newtonsoft.Json;
using SugarCRM.Data.Interface;
using SugarCRM.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SugarCRM.Data.Models
{
    public class AccountModel : AbstractSugarCRMData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
       

        public override async Task<object> Create(CallWrapper activeCallWrapper)
        {
            var apiCall = new APICall(activeCallWrapper, $"Accounts", $"Account_POST(Title: {Name})", $"CREATE Account ({Name})", typeof(Account), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Post);
            apiCall.AddBodyParameter(this);
            activeCallWrapper._integrationConnection.Logger.Log_Technical("D", $"{Identity.AppName} create.Body", JsonConvert.SerializeObject(this));
            var output = (Account)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override async Task<object> Delete(CallWrapper activeCallWrapper, object _id)
        {
            var apiCall = new APICall(activeCallWrapper, $"/Accounts/{Id}", $"Account_DELETE(Id: {Id})",
                $"DELETE Account ({Id})", typeof(Account), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Delete);
            var output = (Account)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override async Task<object> Get(CallWrapper activeCallWrapper, object _id)
        {
            var apiCall = new APICall(activeCallWrapper, $"/Accounts/" + Convert.ToString(Id), $"Account_GET(id: {Id})",
                $"LOAD Account ({Id})", typeof(Account), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Get);

            var output = (Account)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override object GetPrimaryId()
        {
            return Id;
        }

        public override Task<List<BulkTransferRequest>> Poll(CallWrapper activeCallWrapper, string filter)
        {
            throw new NotImplementedException();
        }

        //public override async Task<List<BulkTransferRequest>> Poll(CallWrapper activeCallWrapper, string filter)
        //{
        //    var apiCall = new APICall(activeCallWrapper, $"/Accounts", $"Accounts_GET()",
        //        $"POLL Accounts", typeof(List<Account>), activeCallWrapper?.TrackingGuid,
        //        Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Get);

        //    var initalOutput = (List<Account>)await apiCall.ProcessRequestAsync();

        //    //The API call above gets ALL accounts, but this polling procedure should only return the NEW products. Since we don't have many filter
        //    //options on the Fakestore API, we have to get all the accounts, then filter here. 

        //    //In order to only return accounts that have not already been returned via previous POLL requests, we store the highestProductIdPolled.
        //    //Since FakeStore accounts are stored with an incrementing id, we can determine which accounts have not been previously polled by checkign to see
        //    //if they are higher than the previous highestaccountIdPolled value. 
        //    string highestProductIdPolled = string.Empty;
        //    var highestProductIdPolledPD = activeCallWrapper._integrationConnection.Settings.PersistentData.GetValue("highestProductIdPolled");

        //    //If the highestProductIdPolled value from PersistentData exists and is a valid int, that is our starting point. Otherwise, we use the default value of 0
        //    //if (highestProductIdPolledPD != null && int.TryParse(Convert.ToString(highestProductIdPolledPD.Value), out int highestProductIdPolledPDValueInt))
        //        if (highestProductIdPolledPD != null )
        //        highestProductIdPolled = Convert.ToString(highestProductIdPolledPD.Value);
        //    else
        //        highestProductIdPolledPD = new PersistentData() { Name = "highestProductIdPolled" };

        //    //Filter the output to just those products where the id is higher than the highestProductIdPolled
        //    var outputProducts = initalOutput.FindAll(x => x.Id > highestProductIdPolled);

        //    //Now that we have our new list of polled products, we need to update the highestProductIdPolled value in PersistentData to match the id of
        //    //the highest Id our output. If there are no new products (e.g. otherProducts.Count == 0) then there is nothing to save. 
        //    if (outputProducts.Count > 0)
        //    {
        //        highestProductIdPolledPD.Value = outputProducts[outputProducts.Count - 1].Id;
        //        activeCallWrapper._integrationConnection.Settings.PersistentData.SaveValue(highestProductIdPolledPD);
        //    }

        //    var output = new List<BulkTransferRequest>();

        //    foreach (var product in outputProducts)
        //        output.Add(new BulkTransferRequest(Convert.ToString(product.Id)));

        //    return output;
        //}

        public override void SetPrimaryId(string PrimaryId, bool ThrowErrorOnInvalid = false)
        {
            Id = PrimaryId;
        }

        public override async Task<object> Update(CallWrapper activeCallWrapper)
        {
            var apiCall = new APICall(activeCallWrapper, $"/accounts/{Id}", $"Account_PUT(Id: {Id})",
                $"UPDATE Account ({Id})", typeof(Account), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Put);
            apiCall.AddBodyParameter(this);
            activeCallWrapper._integrationConnection.Logger.Log_Technical("D", $"{Identity.AppName} Update.Body", JsonConvert.SerializeObject(this));
            var output = (Account)await apiCall.ProcessRequestAsync();
            return output;
        }
    }



    
}
