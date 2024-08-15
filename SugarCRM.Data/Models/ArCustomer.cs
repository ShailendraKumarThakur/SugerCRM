using Integration.Abstract.Helpers;
using Newtonsoft.Json;
using SugarCRM.Data.Interface;
using SugarCRM.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SugarCRM.Data.Models
{
    public class ArCustomer : AbstractSugarCRMData
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("addtelephone")]
        public string AddTelephone { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("soldtoaddr1")]
        public string SoldToAddr1 { get; set; }
        [JsonProperty("soldtoaddr2")]
        public string SoldToAddr2 { get; set; }
        [JsonProperty("soldtoaddr3")]
        public string SoldToAddr3 { get; set; }
        [JsonProperty("soldtoaddr3loc")]
        public string SoldToAddr3Loc { get; set; }
        [JsonProperty("soldtoaddr4")]
        public string SoldToAddr4 { get; set; }
        [JsonProperty("soldtoaddr5")]
        public string SoldToAddr5 { get; set; }
        [JsonProperty("soldpostalcode")]
        public string SoldPostalCode { get; set; }
        [JsonProperty("soldtogpslat")]
        public decimal SoldToGpsLat { get; set; }
        [JsonProperty("soldtogpslong")]
        public decimal SoldToGpsLong { get; set; }
        [JsonProperty("languagecode")]
        public string LanguageCode { get; set; }

        public override async Task<object> Create(CallWrapper activeCallWrapper)
        {
            var apiCall = new APICall(activeCallWrapper,$"/arCustomers"+Customer,$"Customer_GET(customar:{Customer})",
                $"LOAD Customer ({Customer})",typeof(ArCustomer),activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER,RestSharp.Method.Get);

            var output = (ArCustomer)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override async Task<object> Delete(CallWrapper activeCallWrapper, object _id)
        {
            var apiCall = new APICall(activeCallWrapper, $"/arCustomers/ {Customer}", $"Customer_DELETE(Id: {Customer})",
                $"DELETE Customer ({Customer})", typeof(ArCustomer), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Delete);
            var output = (ArCustomer)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override async Task<object> Get(CallWrapper activeCallWrapper, object _id)
        {
            var apiCall = new APICall(activeCallWrapper, $"/arCustomers/" + Convert.ToString(Customer), $"Customer_GET(id: {Customer})",
             $"LOAD Customer ({Customer})", typeof(ArCustomer), activeCallWrapper?.TrackingGuid,
             Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Get);

            var output = (ArCustomer)await apiCall.ProcessRequestAsync();
            return output;
        }

        public override object GetPrimaryId()
        {
            return Customer;
        }

        public override Task<List<BulkTransferRequest>> Poll(CallWrapper activeCallWrapper, string filter)
        {
            throw new NotImplementedException();
        }

        public override void SetPrimaryId(string PrimaryId, bool ThrowErrorOnInvalid = false)
        {
            Customer = PrimaryId;
        }

        public override async Task<object> Update(CallWrapper activeCallWrapper)
        {
            var apiCall = new APICall(activeCallWrapper, $"/arCustomers/{Customer}", $"Customer_PUT(customar: {Customer})",
               $"UPDATE Customer ({Customer})", typeof(ArCustomer), activeCallWrapper?.TrackingGuid,
               Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Put);
            apiCall.AddBodyParameter(this);
            activeCallWrapper._integrationConnection.Logger.Log_Technical("D", $"{Identity.AppName} Update.Body", JsonConvert.SerializeObject(this));
            var output = (ArCustomer)await apiCall.ProcessRequestAsync();
            return output;
        }
    }
}
