﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SugarCRM.DataModels;

using static SugarCRM.Constants;
using Integration.Abstract.Helpers;
using Integration.Abstract.Model;
using SugarCRM.Data.Utilities;
using SugarCRM.Data.IPaaSApi;
using SugarCRM.Data;
using SugarCRM.Data.Models;
using System.Xml.Linq;

namespace SugarCRM.Data.Interface
{
    public class TranslationUtilities : Integration.Abstract.TranslationUtilities
    {

        //Given a mapping collection type and a source object, return the Id of the source object. This is used for ExternalId lookups and saves
        //For example, if we get a Counterpoint Item, we need to return the ITEM_NO.  Other Systems may return id.  
        //In this template project, we abstracted the GetPrimaryId, SetPrimaryId, ModelGetAsync, ModelCreateAsync, ModelUpdateAsync, and ModelDeleteAsync into the DataModels.
        //If you created these in your individual data models (the preferred method), then these specific methods herein do NOT need to be modified.

        public override string GetPrimaryId(Integration.Abstract.Connection connection, int mappingCollectionType, object SourceObject, long? MappingCollectionId = null)
        {
            if (SourceObject == null)
                throw new Exception(string.Format("Call to GetPrimaryId with unhandled parameters: System={0} {1}, sourceObject is null", Identity.AppName, mappingCollectionType));

            //Check for parentonly types. If it is a parentonly class, we want to check the parent's primary id, not the parentonly object itself.
            if (SourceObject is ParentOnly)
                SourceObject = ((ParentOnly)SourceObject).Parent;

            // In most cases we use the GetPrimaryId() call in the model class. If there are exceptions, they can be handled here.  
            if (SourceObject is AbstractSugarCRMData)
            {
                return Convert.ToString(((AbstractSugarCRMData)SourceObject).GetPrimaryId());
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to GetPrimaryId with unhandled parameters: System={0}, {1}, sourceObject type={2}.  No matching object", Identity.AppName, mappingCollectionType, SourceObject.GetType().Name));
        }

        public override void SetPrimaryId(Integration.Abstract.Connection connection, int mappingCollectionType, object SourceObject, string PrimaryId)
        {
            if (SourceObject is AbstractSugarCRMData)
                ((AbstractSugarCRMData)SourceObject).SetPrimaryId(PrimaryId);
            else if (SourceObject is ParentOnly) //There is primary id for ParentOnly data, so there is nothing to do here.
                return;
            else
                //if we make it this far and don't have a matching type, we have an error
                throw new Exception(string.Format("Call to SetPrimaryId with unhandled parameters: System={0}, {1}, sourceObject type={2}", Identity.AppName, mappingCollectionType, SourceObject.GetType().Name));
        }

        public override object GetDestinationObject(Integration.Abstract.Connection connection, int mappingCollectionType)
        {
            switch ((TM_MappingCollectionType)mappingCollectionType)
            {
                case TM_MappingCollectionType.CUSTOMER:
                    return new Account();
                default:
                    // Add Error Log Here???
                    throw new Exception(string.Format("Call to GetDestinationObject with unhandled parameters: {0}, systemType: {1}", mappingCollectionType, Identity.AppName));
            }
        }

        public override Task InitializeData(Integration.Abstract.Connection connection, int mappingCollectionType)
        {
            // nothing to initialize
            return null;
        }

        public override async Task<ResponseObject> ModelGetAsync(Integration.Abstract.Connection connection, int mappingCollectionType, object id)
        {
            object response = null;

            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            var modelObject = GetDestinationObject(connection, mappingCollectionType);
            if (modelObject == null)
                throw new Exception(string.Format("Call to CollectionGet with unhandled parameters: System={0} {1}, sourceObject could not be created", Identity.AppName, mappingCollectionType));

            if (modelObject is AbstractSugarCRMData)
            {
                response = await ((AbstractSugarCRMData)modelObject).Get(wrapper, id);

                var retVal = new ResponseObject();
                StandardUtilities.AssignQuotaValues(retVal, response);
                return retVal;
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to CollectionGet with unhandled parameters: System={0}, {1}, sourceObject type={2}", Identity.AppName, mappingCollectionType, modelObject.GetType().Name));
        }

        public override async Task<ResponseObject> ModelCreateAsync(Integration.Abstract.Connection connection, int mappingCollectionType, object sourceObject, object id, CollisionHandlerSettings collisionHandlerSettings)
        {
            object response = null;

            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            if (sourceObject == null)
                throw new Exception(string.Format("Call to CollectionCreate with unhandled parameters: System={0} {1}, sourceObject is null", Identity.AppName, mappingCollectionType));

            if (sourceObject is AbstractSugarCRMData)
            {
                response = await ((AbstractSugarCRMData)sourceObject).Create(wrapper);

                var retVal = new ResponseObject();
                StandardUtilities.AssignQuotaValues(retVal, response);
                return retVal;
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to CollectionCreate with unhandled parameters: System={0}, {1}, sourceObject type={2}", Identity.AppName, mappingCollectionType, sourceObject.GetType().Name));
        }

        public override async Task<ResponseObject> ModelUpdateAsync(Integration.Abstract.Connection connection, int mappingCollectionType, object sourceObject, object id, CollisionHandlerSettings collisionHandlerSettings)
        {
            object response = null;

            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            if (sourceObject == null)
                throw new Exception(string.Format("Call to CollectionUpdate with unhandled parameters: System={0} {1}, sourceObject is null", Identity.AppName, mappingCollectionType));

            // In most cases we use the GetPrimaryId() call in the model class. There are a few exceptions we need to check for first though:
            if (sourceObject is AbstractSugarCRMData)
            {
                response = await ((AbstractSugarCRMData)sourceObject).Update(wrapper);

                var retVal = new ResponseObject();
                StandardUtilities.AssignQuotaValues(retVal, response);
                return retVal;
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to CollectionUpdate with unhandled parameters: System={0}, {1}, sourceObject type={2}", Identity.AppName, mappingCollectionType, sourceObject.GetType().Name));
        }

        public override async Task<ResponseObject> ModelDeleteAsync(Integration.Abstract.Connection connection, int mappingCollectionType, object id)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            var Object = GetDestinationObject(connection, mappingCollectionType);
            if (Object == null)
                throw new Exception(string.Format("Call to CollectionDelete with unhandled parameters: System={0} {1}, sourceObject could not be created", Identity.AppName, mappingCollectionType));

            // In most cases we use the GetPrimaryId() call in the model class. There are a few exceptions we need to check for first though:
            if (Object is AbstractSugarCRMData)
            {
                await ((AbstractSugarCRMData)Object).Delete(wrapper, id);

                var retVal = new ResponseObject();
                retVal.TotalAPICallsMade = 1;
                return retVal;
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to CollectionDelete with unhandled parameters: System={0}, {1}, ObjectId={2}", Identity.AppName, mappingCollectionType, id));
        }

        //The PollRequest method is optional to implement. It is only necessary for systems that use polling, rather than (or in addition to) webhooks.
        public new async Task<List<BulkTransferRequest>> PollRequest(Integration.Abstract.Connection connection, int mappingCollectionType, string filter)
        {
            List<BulkTransferRequest> response = null;

            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            var modelObject = GetDestinationObject(connection, mappingCollectionType);
            if (modelObject == null)
                throw new Exception(string.Format("Call to PollRequest with unhandled parameters: System={0} {1}, sourceObject could not be created", Identity.AppName, mappingCollectionType));

            if (modelObject is AbstractSugarCRMData)
            {
                response = await ((AbstractSugarCRMData)modelObject).Poll(wrapper, filter);
                return response;
            }

            // If we make it this far and don't have a matching type, we have an error
            throw new Exception(string.Format("Call to CollectionGet with unhandled parameters: System={0}, {1}, sourceObject type={2}", Identity.AppName, mappingCollectionType, modelObject.GetType().Name));
        }


        public override List<TranslationExternalId> CollectAdditionalExternalIds(Integration.Abstract.Connection connection, int mappingCollectionType, object sourceObject, object destinationObject)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            // Add tasks here

            return null;
        }

        // Some iPaaS objects have child collections which are obtained from seperate 3rd Party end-points.
        // In this case, we want to create an association for each childCollection with the MappingCollectionType.  A childMapping Collection must be created in iPaaS that corresponds to each.
        // If this SugarCRM does not have child records, then return an empty collection
        public override List<ChildMapping> GetChildMappings(Integration.Abstract.Connection connection, int mappingCollectionType, long mappingResponseId, int mappingDirection)
        {
            var retVal = new List<ChildMapping>();
            switch ((TM_MappingCollectionType)mappingCollectionType)
            {
                // This example demonstrates how to process the CUSTOMER_CATEGORY ToIpaas and assigning the value to the customerGroup field during the CUSTOMER HookEvent.

                case TM_MappingCollectionType.CUSTOMER:
                    retVal.Add(new ChildMapping() { MappingCollectionType = (int)TM_MappingCollectionType.CUSTOMER_ADDRESS, ParentOnly = true });
                    break;
                case TM_MappingCollectionType.TRANSACTION:
                    retVal.Add(new ChildMapping() { Field = "LineItems", MappingCollectionType = (int)TM_MappingCollectionType.TRANSACTION_LINE });
                    retVal.Add(new ChildMapping() { Field = "Payments", MappingCollectionType = (int)TM_MappingCollectionType.TRANSACTION_PAYMENT });
                    retVal.Add(new ChildMapping() { Field = "Notes", MappingCollectionType = (int)TM_MappingCollectionType.TRANSACTION_PAYMENT });
                    break;
                default:
                    break;
            }
            return retVal;
        }

        public override async Task<object> HandlePrerequisite(Integration.Abstract.Connection connection, TransferRequest transferRequest)
        {
            // ===================================================================
            //If there are priority actions to be performed before attempting this HookEvent, Specify to run first here.
            // ===================================================================

            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            // This example demonstrates how to initiate a HookEvent for CUSTOMER_CATEGORY using the value in the customerGroup field before processing the current CUSTOMER HookEvent.

            if (transferRequest.MappingDirection == (int)TM_MappingDirection.TO_IPAAS)
            {
                switch ((TM_MappingCollectionType)transferRequest.MappingCollectionType)
                {
                    // This example demonstrates how to initiate a HookEvent for CUSTOMER_CATEGORY using the value in the customerGroup field before processing the current CUSTOMER HookEvent.
                    // The payload in the Transfer Request would include the body for the requested hook.  Replace: new Dictionary<string, string>()

                    //case TM_MappingCollectionType.CUSTOMER:
                    //            var CustomerBillingAddressRequest = new TransferRequest(connection: conn,
                    //                    mappingCollectionType: (int)TM_MappingCollectionType.CUSTOMER_ADDRESS, mappingDirection: transferRequest.MappingDirection, payload: new Dictionary<string, string>(),
                    //                    scope: "customer/address/created", childRequest: true);

                    //            conn.DataHandlerFunction(CustomerBillingAddressRequest);
                    //    break;
                    default:
                        connection.Logger.Log_Technical("V", string.Format("{0}.TranslationUtiltiies.HandlePrerequisite", Identity.AppName), "No prereqs required.");
                        break;
                }
            }
            return null;
        }

        public override async Task<object> HandlePostActions(Integration.Abstract.Connection connection, TransferRequest transferRequest)
        {
            // ===================================================================
            //If there are secondary actions to be performed upon completion of the current HookEvent, associate it here.
            // ===================================================================

            var conn = (Connection)connection;
            var SugarCRM_wrapper = (CallWrapper)conn.CallWrapper;
            var ipaas_wrapper = (IPaaSApiCallWrapper)conn.IPaasApiCallWrapper;

            if (transferRequest.MappingDirection == (int)TM_MappingDirection.TO_IPAAS)
            {
                switch ((TM_MappingCollectionType)transferRequest.MappingCollectionType)
                {
                    // This example demonstrates how to create a customer address Request after completing the customer.
                    // The payload in the Transfer Request would include the body for the requested hook.  Replace: new Dictionary<string, string>()

                    //case TM_MappingCollectionType.CUSTOMER:
                    //            var CustomerBillingAddressRequest = new TransferRequest(connection: conn,
                    //                    mappingCollectionType: (int)TM_MappingCollectionType.CUSTOMER_ADDRESS, mappingDirection: transferRequest.MappingDirection, payload: new Dictionary<string, string>(),
                    //                    scope: "customer/address/created", childRequest: true);

                    //            conn.DataHandlerFunction(CustomerBillingAddressRequest);
                    //            return null;
                    default:
                        connection.Logger.Log_Technical("V", string.Format("{0}.TranslationUtiltiies.HandlePostActions", Identity.AppName), "No post actions required.");
                        break;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mappingCollectionType"></param>
        /// <returns></returns>
        public override async Task<ResponseObject> UpdateWebhookSubscriptionAsync(Integration.Abstract.Connection connection, string scope, bool subscribed)
        {
            // If External webhooks are supported in this SugarCRM, this is where you handle turning them on
            // subscribed represents the toggle state

            var retVal = new ResponseObject();

            var conn = (Connection)connection;
            var SugarCRM_wrapper = (CallWrapper)conn.CallWrapper;

            retVal.TotalAPICallsMade = 0;

            if (scope == "Account")
            {
                // Add Sugar API Call here
                if (subscribed)
                {
                    var apiCall = new APICall(SugarCRM_wrapper, $"/WebLogicHooks", $"WebLogicHook_POST(Title: WebLogicHook)", $"CREATE WebLogicHook)", typeof(WebLogicHook), SugarCRM_wrapper?.TrackingGuid,
             Constants.TM_MappingCollectionType.NONE, RestSharp.Method.Post);

                    WebLogicHook objWebLogicHook = new WebLogicHook()
                    {
                        Name = "Webhook created from Data Integration",
                        Description = "This is testing purpose from Integration",
                        Webhook_Target_Module = "Accounts",
                        Deleted = false,
                        Request_Method = "POST",
                        Url = "https://stagingapi.ipaas.com/hookapi/v2/dynamic/SugarCRM/?subscription=" + conn.Settings.WebhookApiKey,
                        Trigger_Event = "after_save",
                        Following = false,
                        My_Favorite = false,
                        _Module = "WebLogicHooks"
                    };

                    apiCall.AddBodyParameter(JsonConvert.SerializeObject(objWebLogicHook));
                    SugarCRM_wrapper._SugarCRMConnection.Logger.Log_Technical("D", $"{Identity.AppName} create.Body", JsonConvert.SerializeObject(objWebLogicHook));
                    var output = (Account)await apiCall.ProcessRequestAsync();
                    retVal.TotalAPICallsMade++;
                }
                else
                {

                    var apiCall = new APICall(SugarCRM_wrapper, $"/WebLogicHooks", $"WebLogicHook_GET(Title: WebLogicHook)", $"GET WebLogicHook)", typeof(List<WebLogicHook>), SugarCRM_wrapper?.TrackingGuid,
          Constants.TM_MappingCollectionType.NONE, RestSharp.Method.Get);                                       

                    var webhookList = (List<WebLogicHook>)await apiCall.ProcessRequestAsync();
                    retVal.TotalAPICallsMade++;

                    var webhook = webhookList.Find(x => x.Name == "Webhook created from Data Integration");
                    if (webhook != null)
                    {
                        var apiCallWebHook = new APICall(SugarCRM_wrapper, $"/WebLogicHooks" + webhook.Id, $"WebLogicHook_DELETE(Title: WebLogicHook)", $"DELETE WebLogicHook)", typeof(WebLogicHook), SugarCRM_wrapper?.TrackingGuid,
           Constants.TM_MappingCollectionType.NONE, RestSharp.Method.Delete);

                        //apiCall.AddBodyParameter(JsonConvert.SerializeObject(objWebLogicHook));
                        var output = (WebLogicHook)await apiCallWebHook.ProcessRequestAsync();
                        retVal.TotalAPICallsMade++;
                    }                    
                }

                //return output;


               
            }

            return retVal;
        }

        /// <summary>
        /// Allows an external DLL to estimate how many API calls will be needed for a each CREATE events in order to claim the slots against rate limit settings at the beginning. 
        /// Once the transfer is complete, actual API calls will be compared to the claimed API calls and will adjust the available API call limit up or down as necessary. 
        /// </summary>
        /// <param name="mappingCollectionType"></param>
        /// <returns></returns>
        public new long EstimateTotalAPICallsMade(Integration.Abstract.Connection connection, int mappingCollectionType, object sourceObject)
        {
            // By Default, we estimate 1
            long retVal = 1;

            //switch ((TM_MappingCollectionType)mappingCollectionType)
            //{
            //    // This example demonstrates how to adjust the estimate higher than 1 if certain POST events have multiple calls within their CallWrapper. 
            //    // We always have to serialize and deserialize the sourceObject into the local model before we can access it.
            //    case TM_MappingCollectionType.CUSTOMER:
            //        var sourceObject_JSON = JsonConvert.SerializeObject(sourceObject);
            //        var sourceObject_ExtCustomer = JsonConvert.DeserializeObject<SugarCRM.Data.IPaaSApi.Model.CustomerResponse>(sourceObject_JSON);

            //        //If a collection requires multiple POST calls, in this case 2 each, then calculate it this way
            //        retVal += (sourceObject_ExtCustomer.Options == null ? 0 : sourceObject_ExtCustomer.Options.Count * 2);
            //        break;
            //}

            return retVal;
        }

        public override async Task<string> ValidateConnection(Integration.Abstract.Connection connection)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;
            connection.Logger.Log_Technical("D", String.Format("{0}.TranslationUtilities.ValidateConnection", Identity.AppName), "Begin validation");
            var retVal = await wrapper.ValidateConnection();
            connection.Logger.Log_Technical("D", String.Format("{0}.TranslationUtilities.ValidateConnection", Identity.AppName), "Completed validation");
            return retVal;
        }
    }
}
