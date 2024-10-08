﻿using Integration.Abstract.Helpers;
using SugarCRM.Data.Interface;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SugarCRM.Constants;
using SugarCRM.Data.Utilities;

namespace SugarCRM.DataModels
{
    // In this file, we are creating a Data Model to hold the properties to be received from a 3rd Party API Get request or which will be delivered in a Post/Put call.
    // Each Data Model should inherit either AbstractSugarCRMData or AbstractSugarCRMData or AbstractSugarCRMDataWithCustomFields.
    // - Use the latter if the 3rd party object supports a list or dictionary of key/value pairs representing custom fields).

    public class Template : AbstractSugarCRMData
    {
        #region Properties
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; } //id of the customer

        //[JsonProperty("third_party_field_name", NullValueHandling = NullValueHandling.Ignore)]
        //public string ThirdPartyFieldName { get; set; }

        //[JsonIgnore]
        //public string LocalOnlyFieldName { get; set; } 
        #endregion

        #region OperationMethods
        public override object GetPrimaryId()
        {
            return Convert.ToString(Id);
        }

        public override void SetPrimaryId(string PrimaryId, bool ThrowErrorOnInvalid = false)
        {
            int Id_value;
            if (!int.TryParse(PrimaryId, out Id_value))
                HandleInvalidPrimaryId(PrimaryId, ThrowErrorOnInvalid, "Template");
            else
                Id = Id_value;
        }

        public override async Task<object> Get(CallWrapper activeCallWrapper, object id)
        {

            //var apiCall = new APICall(activeCallWrapper, $"/admin/api/{activeCallWrapper?.ApiVersion}/customers/" + id + ".json", "Customer_GET(id: " + id + ")",
            //    "LOAD Customer (" + id + ")", typeof(RequestCustomer), activeCallWrapper?.TrackingGuid,
            //    Constants.TM_MappingCollectionType.CUSTOMER);
            //var output = (RequestCustomer)await apiCall.ProcessRequestAsync();
            //return output.customer;

            throw new NotImplementedException();
        }

        public override async Task<object> Create(CallWrapper activeCallWrapper)
        {
            throw new NotImplementedException();
        }

        public override async Task<object> Update(CallWrapper activeCallWrapper)
        {
            throw new NotImplementedException();
        }

        public override async Task<object> Delete(CallWrapper activeCallWrapper, object id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<BulkTransferRequest>> Poll(CallWrapper activeCallWrapper, string filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}
