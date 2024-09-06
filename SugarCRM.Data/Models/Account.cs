using Integration.Abstract.Helpers;
using Integration.Abstract.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SugarCRM.Data.Interface;
using SugarCRM.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SugarCRM.Data.Models
{
    public class Account : AbstractSugarCRMData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date_entered")]
        public DateTime Date_Entered { get; set; }
        [JsonProperty("date_modified")]
        public DateTime Date_Modified { get; set; }
        [JsonProperty("modified_user_id")]
        public string Modified_User_Id { get; set; }
        [JsonProperty("modified_by_name")]
        public string Modified_By_Name { get; set; }
        [JsonProperty("created_by")]
        public string Created_By { get; set; }
        [JsonProperty("created_by_name")]
        public string Created_By_Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("googleplus")]
        public string GooglePlus { get; set; }
        [JsonProperty("account_type")]
        public string Account_Type { get; set; }
        [JsonProperty("industry")]
        public string Industry { get; set; }
        [JsonProperty("annual_revenue")]
        public string Annual_Rrevenue { get; set; }
        [JsonProperty("phone_fax")]
        public string Phone_Fax { get; set; }
        [JsonProperty("billing_address_street")]
        public string Billing_Address_Street { get; set; }
        [JsonProperty("billing_address_street_2")]
        public string Billing_Address_Street_2 { get; set; }
        [JsonProperty("billing_address_street_3")]
        public string Billing_Address_Street_3 { get; set; }
        [JsonProperty("billing_address_street_4")]
        public string Billing_Address_Street_4 { get; set; }
        [JsonProperty("billing_address_city")]
        public string Billing_Address_City { get; set; }
        [JsonProperty("billing_address_state")]
        public string Billing_Address_State { get; set; }
        [JsonProperty("billing_address_postalcode")]
        public string Billing_Address_PostalCode { get; set; }
        [JsonProperty("billing_address_country")]
        public string Billing_Address_Country { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
        [JsonProperty("phone_office")]
        public string Phone_Office { get; set; }
        [JsonProperty("phone_alternate")]
        public string Phone_Alternate { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("ownership")]
        public string Ownership { get; set; }
        [JsonProperty("employees")]
        public string Employees { get; set; }
        [JsonProperty("ticker_symbol")]
        public string Ticker_Symbol { get; set; }
        [JsonProperty("Shipping_Address_Street")]
        public string Shipping_Address_Street { get; set; }
        [JsonProperty("shipping_address_street_2")]
        public string Shipping_Address_Street_2 { get; set; }
        [JsonProperty("shipping_address_street_3")]
        public string Shipping_Address_Street_3 { get; set; }
        [JsonProperty("shipping_address_street_4")]
        public string Shipping_Address_Street_4 { get; set; }
        [JsonProperty("shipping_address_city")]
        public string Shipping_Address_City { get; set; }
        [JsonProperty("shipping_address_state")]
        public string Shipping_Address_State { get; set; }
        [JsonProperty("shipping_address_postalcode")]
        public string Shipping_Address_PostalCode { get; set; }
        [JsonProperty("shipping_address_country")]
        public string Shipping_Address_Country { get; set; }
        [JsonProperty("service_level")]
        public string Service_Level { get; set; }
        [JsonProperty("parent_id")]
        public string Parent_Id { get; set; }
        [JsonProperty("sic_code")]
        public string Sic_Code { get; set; }
        [JsonProperty("duns_num")]
        public string Duns_Num { get; set; }
        [JsonProperty("parent_name")]
        public string Parent_Name { get; set; }
        [JsonProperty("business_center_name")]
        public string Business_Center_Name { get; set; }
        [JsonProperty("business_center_id")]
        public string Business_Center_Id { get; set; }
        [JsonProperty("campaign_id")]
        public string Campaign_Id { get; set; }
        [JsonProperty("campaign_name")]
        public string Campaign_Name { get; set; }
        [JsonProperty("next_renewal_date")]
        public string Next_Renewal_Date { get; set; }
        [JsonProperty("widget_next_renewal_date")]
        public string Widget_Next_Renewal_Date { get; set; }
        [JsonProperty("hint_account_size")]
        public string Hint_Account_Size { get; set; }
        [JsonProperty("hint_account_industry")]
        public string Hint_Account_Industry { get; set; }
        [JsonProperty("hint_account_location")]
        public string Hint_Account_Location { get; set; }
        [JsonProperty("hint_account_industry_tags")]
        public string Hint_Account_Industry_Tags { get; set; }
        [JsonProperty("hint_account_founded_year")]
        public string Hint_Account_Founded_Year { get; set; }
        [JsonProperty("hint_account_facebook_handle")]
        public string Hint_Account_Fcebook_Handle { get; set; }
        [JsonProperty("hint_account_logo")]
        public string Hint_Account_Logo { get; set; }
        [JsonProperty("hint_account_pic")]
        public string Hint_Account_Pic { get; set; }
        [JsonProperty("hint_account_naics_code_lbl")]
        public string Hint_Account_Naics_Code_Lbl { get; set; }
        [JsonProperty("hint_account_fiscal_year_end")]
        public string Hint_Account_Fiscal_Year_End { get; set; }
        [JsonProperty("geocode_status")]
        public string Geocode_Status { get; set; }
        [JsonProperty("following")]
        public bool Following { get; set; }
        [JsonProperty("my_favorite")]
        public bool My_Favorite { get; set; }
        [JsonProperty("sync_key")]
        public string Sync_Key { get; set; }
        [JsonProperty("assigned_user_id")]
        public string Assigned_User_Id { get; set; }
        [JsonProperty("assigned_user_name")]
        public string Assigned_User_Name { get; set; }
        [JsonProperty("team_count")]
        public string Team_Count { get; set; }
        [JsonProperty("team_name")]
        public Team_Name[] Team_Name { get; set; }
        [JsonProperty("email")]
        public Email[] Email { get; set; }
        [JsonProperty("email1")]
        public string Email1 { get; set; }
        [JsonProperty("email2")]
        public string Email2 { get; set; }
        [JsonProperty("invalid_email")]
        public bool Invalid_Email { get; set; }
        [JsonProperty("email_opt_out")]
        public bool Email_Opt_Out { get; set; }
        [JsonProperty("email_addresses_non_primary")]
        public string Email_Addresses_Non_Primary { get; set; }
        [JsonProperty("is_escalated")]
        public bool Is_Escalated { get; set; }
        [JsonProperty("dri_workflow_template_id")]
        public string Dri_Workflow_Template_Id { get; set; }
        [JsonProperty("dri_workflow_template_name")]
        public string Dri_Workflow_Template_Name { get; set; }
        [JsonProperty("perform_sugar_action")]
        public bool Perform_Sugar_Action { get; set; }
        [JsonProperty("Latitude_c")]
        public string latitude_c { get; set; }
        [JsonProperty("Longitude_c")]
        public string longitude_c { get; set; }
        [JsonProperty("Module")]
        public string _module { get; set; }
        [JsonProperty("Contacts")]
        public List<Record> Contacts { get; set; }

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
            var apiCall = new APICall(activeCallWrapper, $"/Accounts/" + Convert.ToString(_id), $"Account_GET(id: {_id})",
                $"LOAD Account ({_id})", typeof(Account), activeCallWrapper?.TrackingGuid,
                Constants.TM_MappingCollectionType.CUSTOMER, RestSharp.Method.Get);

            var output = (Account)await apiCall.ProcessRequestAsync();
                       

            //Another API call for contact result that need to assign to contact
            var apiCallContact = new APICall(activeCallWrapper, $"/Contacts/filter", $"Contact_POST(id: {_id})",
               $"LOAD Contact ({_id})", typeof(Contact), activeCallWrapper?.TrackingGuid,
               Constants.TM_MappingCollectionType.CUSTOMER_CONTACT, RestSharp.Method.Post);

            dynamic filterWrapper = new JObject();
            dynamic filterEmbedded = new JObject();
            //dynamic name = new JObject(); 
            JObject name = JObject.FromObject(new
            {
                account_id = _id
            });

            filterEmbedded.name = name;
            JArray filter = new JArray();
            filter.Add(name);
            filterWrapper.filter = filter;
            apiCallContact.AddBodyParameter(filter);


            var contactOutput = (Contact)await apiCallContact.ProcessRequestAsync();

            if (output.Contacts == null)
            {
                output.Contacts = new List<Record>();
            }

            output.Contacts.AddRange(contactOutput.records);
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
        //    if (highestProductIdPolledPD != null)
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



    public class Team_Name
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("name_2")]
        public string Name_2 { get; set; }
        [JsonProperty("primary")]
        public bool Primary { get; set; }
        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }

    public class Email
    {
        [JsonProperty("Email_Address")]
        public string email_address { get; set; }
        [JsonProperty("invalid_email")]
        public bool Invalid_Email { get; set; }
        [JsonProperty("opt_out")]
        public bool Opt_Out { get; set; }
        [JsonProperty("email_address_id")]
        public string Email_Address_Id { get; set; }
        [JsonProperty("primary_address")]
        public bool Primary_Address { get; set; }
        [JsonProperty("reply_to_address")]
        public bool Reply_To_Address { get; set; }
    }
}
