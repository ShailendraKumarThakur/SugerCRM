using Integration.Abstract.Helpers;
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
    public class Contact
    {
        public int next_offset { get; set; }
        public Record[] records { get; set; }
    }
    public class Record
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
        [JsonProperty("modified_user_link")]
        public Modified_User_Link Modified_User_Link { get; set; }
        [JsonProperty("created_by")]
        public string Created_By { get; set; }
        [JsonProperty("created_by_name")]
        public string Created_By_Name { get; set; }
        [JsonProperty("created_by_link")]
        public Created_By_Link Created_By_Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("salutation")]
        public string Salutation { get; set; }
        [JsonProperty("first_name")]
        public string First_Name { get; set; }
        [JsonProperty("last_name")]
        public string Last_Name { get; set; }
        [JsonProperty("full_name")]
        public string Full_Name { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("googleplus")]
        public string GooglePlus { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("do_not_call")]
        public bool Do_Not_Call { get; set; }
        [JsonProperty("phone_home")]
        public string Phone_Home { get; set; }
        [JsonProperty("phone_mobile")]
        public string Phone_Mobile { get; set; }
        [JsonProperty("phone_work")]
        public string Phone_Work { get; set; }
        [JsonProperty("phone_other")]
        public string Phone_Other { get; set; }
        [JsonProperty("phone_fax")]
        public string Phone_Fax { get; set; }
        [JsonProperty("primary_address_street")]
        public string Primary_Address_Street { get; set; }
        [JsonProperty("primary_address_street_2")]
        public string Primary_Address_Street_2 { get; set; }
        [JsonProperty("primary_address_street_3")]
        public string Primary_Address_Street_3 { get; set; }
        [JsonProperty("primary_address_city")]
        public string Primary_Address_City { get; set; }
        [JsonProperty("primary_address_state")]
        public string Primary_Address_State { get; set; }
        [JsonProperty("primary_address_postalcode")]
        public string Primary_Address_PostalCode { get; set; }
        [JsonProperty("primary_address_country")]
        public string Primary_Address_Country { get; set; }
        [JsonProperty("alt_address_street")]
        public string Alt_Address_Street { get; set; }
        [JsonProperty("alt_address_street_2")]
        public string Alt_Address_Street_2 { get; set; }
        [JsonProperty("alt_address_street_3")]
        public string Alt_Address_Street_3 { get; set; }
        [JsonProperty("alt_address_city")]
        public string Alt_Address_City { get; set; }
        [JsonProperty("alt_address_state")]
        public string Alt_Address_State { get; set; }
        [JsonProperty("alt_address_postalcode")]
        public string Alt_Address_PostalCode { get; set; }
        [JsonProperty("alt_address_country")]
        public string Alt_Address_Country { get; set; }
        [JsonProperty("assistant")]
        public string Assistant { get; set; }
        [JsonProperty("assistant_phone")]
        public string Assistant_Phone { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("email_and_name1")]
        public string Email_And_Name1 { get; set; }
        [JsonProperty("lead_source")]
        public string Lead_Source { get; set; }
        [JsonProperty("account_name")]
        public string Account_Name { get; set; }
        [JsonProperty("accounts")]
        public Account Accounts { get; set; }
        [JsonProperty("account_id")]
        public string Account_Id { get; set; }
        [JsonProperty("dnb_principal_id")]
        public string Dnb_Principal_Id { get; set; }
        [JsonProperty("opportunity_role_fields")]
        public string Opportunity_Role_fields { get; set; }
        [JsonProperty("opportunities")]
        public Opportunities Opportunities { get; set; }
        [JsonProperty("opportunity_role_id")]
        public string Opportunity_Role_Id { get; set; }
        [JsonProperty("opportunity_role")]
        public string Opportunity_Role { get; set; }
        [JsonProperty("reports_to_id")]
        public string Reports_To_Id { get; set; }
        [JsonProperty("report_to_name")]
        public string Report_To_Name { get; set; }
        [JsonProperty("reports_to_link")]
        public Reports_To_Link Reports_To_Link { get; set; }
        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }
        [JsonProperty("portal_name")]
        public string Portal_Name { get; set; }
        [JsonProperty("portal_active")]
        public bool Portal_Active { get; set; }
        [JsonProperty("portal_password")]
        public object Portal_Password { get; set; }
        [JsonProperty("portal_password1")]
        public object Portal_Password1 { get; set; }
        [JsonProperty("portal_app")]
        public string Portal_App { get; set; }
        [JsonProperty("portal_user_company_name")]
        public string Portal_User_Company_Name { get; set; }
        [JsonProperty("preferred_language")]
        public string Preferred_Language { get; set; }
        [JsonProperty("cookie_consent")]
        public bool Cookie_Consent { get; set; }
        [JsonProperty("cookie_consent_received_on")]
        public string Cookie_Consent_Received_On { get; set; }
        [JsonProperty("business_center_name")]
        public string Business_Center_Name { get; set; }
        [JsonProperty("business_centers")]
        public Business_Centers Business_Centers { get; set; }
        [JsonProperty("business_center_id")]
        public string Business_Center_Id { get; set; }
        [JsonProperty("dp_business_purpose")]
        public object[] Dp_Business_Purpose { get; set; }
        [JsonProperty("dp_consent_last_updated")]
        public string Dp_Consent_Last_Updated { get; set; }
        [JsonProperty("campaign_id")]
        public string Campaign_Id { get; set; }
        [JsonProperty("campaign_name")]
        public string Campaign_Name { get; set; }
        [JsonProperty("campaign_contacts")]
        public Campaign_Contacts Campaign_Contacts { get; set; }
        [JsonProperty("c_accept_status_fields")]
        public string C_Accept_Status_Fields { get; set; }
        [JsonProperty("calls")]
        public Calls Calls { get; set; }
        [JsonProperty("m_accept_status_fields")]
        public string M_Accept_Status_Fields { get; set; }
        [JsonProperty("meetings")]
        public Meetings Meetings { get; set; }
        [JsonProperty("accept_status_id")]
        public string Accept_Status_Id { get; set; }
        [JsonProperty("accept_status_name")]
        public string Accept_Status_Name { get; set; }
        [JsonProperty("accept_status_calls")]
        public string Accept_Status_Calls { get; set; }
        [JsonProperty("accept_status_meetings")]
        public string Accept_Status_Meetings { get; set; }
        [JsonProperty("accept_status_messages")]
        public string Accept_Status_Messages { get; set; }
        [JsonProperty("hint_account_size")]
        public string Hint_Account_Size { get; set; }
        [JsonProperty("hint_account_industry")]
        public string Hint_Account_Industry { get; set; }
        [JsonProperty("hint_account_location")]
        public string Hint_Account_Location { get; set; }
        [JsonProperty("hint_account_description")]
        public string Hint_Account_Description { get; set; }
        [JsonProperty("hint_job_2")]
        public string Hint_Job_2 { get; set; }
        [JsonProperty("hint_education")]
        public string Hint_Education { get; set; }
        [JsonProperty("hint_education_2")]
        public string Hint_Education_2 { get; set; }
        [JsonProperty("hint_facebook")]
        public string Hint_Facebook { get; set; }
        [JsonProperty("hint_twitter")]
        public string Hint_Twitter { get; set; }
        [JsonProperty("hint_industry_tags")]
        public string Hint_Industry_Tags { get; set; }
        [JsonProperty("hint_account_founded_year")]
        public string Hint_Account_Founded_Year { get; set; }
        [JsonProperty("hint_account_facebook_handle")]
        public string Hint_Account_Facebook_Handle { get; set; }
        [JsonProperty("hint_account_twitter_handle")]
        public string Hint_Account_Twitter_Handle { get; set; }
        [JsonProperty("hint_account_logo")]
        public string Hint_Account_Logo { get; set; }
        [JsonProperty("hint_contact_pic")]
        public string Hint_Contact_Pic { get; set; }
        [JsonProperty("hint_photo")]
        public string Hint_Photo { get; set; }
        [JsonProperty("hint_phone_1")]
        public string Hint_Phone_1 { get; set; }
        [JsonProperty("hint_phone_2")]
        public string Hint_Phone_2 { get; set; }
        [JsonProperty("hint_account_website")]
        public string Hint_Account_Website { get; set; }
        [JsonProperty("hint_account_naics_code_lbl")]
        public string Hint_Account_Naics_Code_Lbl { get; set; }
        [JsonProperty("hint_account_sic_code_label")]
        public string Hint_Account_Sic_Code_Label { get; set; }
        [JsonProperty("hint_account_fiscal_year_end")]
        public string Hint_Account_Fiscal_Year_End { get; set; }
        [JsonProperty("hint_account_annual_revenue")]
        public string Hint_Account_Annual_Revenue { get; set; }
        [JsonProperty("geocode_status")]
        public string GeoCode_Status { get; set; }
        [JsonProperty("sync_contact")]
        public bool Sync_Contact { get; set; }
        [JsonProperty("market_interest_prediction_score")]
        public string Market_Interest_Prediction_Score { get; set; }
        [JsonProperty("market_score")]
        public object Market_Score { get; set; }
        [JsonProperty("mkto_sync")]
        public bool Mkto_Sync { get; set; }
        [JsonProperty("mkto_id")]
        public object Mkto_Id { get; set; }
        [JsonProperty("mkto_lead_score")]
        public object Mkto_Lead_Score { get; set; }
        [JsonProperty("entry_source")]
        public string Entry_Source { get; set; }
        [JsonProperty("site_user_id")]
        public string Site_User_Id { get; set; }
        [JsonProperty("following")]
        public bool Following { get; set; }
        [JsonProperty("my_favorite")]
        public bool My_Favorite { get; set; }
        [JsonProperty("tag")]
        public object[] Tag { get; set; }
        [JsonProperty("locked_fields")]
        public object[] Locked_Fields { get; set; }
        [JsonProperty("sync_key")]
        public string Sync_Key { get; set; }
        [JsonProperty("assigned_user_id")]
        public string Assigned_User_Id { get; set; }
        [JsonProperty("assigned_user_name")]
        public string Assigned_User_Name { get; set; }
        [JsonProperty("assigned_user_link")]
        public Assigned_User_Link Assigned_User_Link { get; set; }
        [JsonProperty("team_count")]
        public string Team_Count { get; set; }
        [JsonProperty("team_count_link")]
        public Team_Count_Link Team_Count_Link { get; set; }
        [JsonProperty("team_name")]
        public Team_Name[] Team_Name { get; set; }
        [JsonProperty("email")]
        public object[] Email { get; set; }
        [JsonProperty("email1")]
        public string Email1 { get; set; }
        [JsonProperty("email2")]
        public string Email2 { get; set; }
        [JsonProperty("invalid_email")]
        public string Invalid_Email { get; set; }
        [JsonProperty("email_opt_out")]
        public string Email_Opt_Out { get; set; }
        [JsonProperty("email_addresses_non_primary")]
        public string Email_Addresses_Non_Primary { get; set; }
        [JsonProperty("external_user_id")]
        public string External_User_Id { get; set; }
        [JsonProperty("source_id")]
        public string Source_Id { get; set; }
        [JsonProperty("source_type")]
        public string Source_Type { get; set; }
        [JsonProperty("source_meta")]
        public string Source_Meta { get; set; }
        [JsonProperty("dri_workflow_template_id")]
        public string Dri_Workflow_Template_Id { get; set; }
        [JsonProperty("dri_workflow_template_name")]
        public string Dri_Workflow_Template_Name { get; set; }
        [JsonProperty("dri_workflow_template_link")]
        public Dri_Workflow_Template_Link Dri_Workflow_Template_Link { get; set; }
        [JsonProperty("perform_sugar_action")]
        public bool Perform_Sugar_Action { get; set; }
        [JsonProperty("denorm_account_name")]
        public string Denorm_Account_Name { get; set; }
        [JsonProperty("latitude_c")]
        public string Latitude_C { get; set; }
        [JsonProperty("longitude_c")]
        public string Longitude_C { get; set; }
        //[JsonProperty("_acl")]
        //public _Acl _Acl { get; set; }
        [JsonProperty("_module")]
        public string _Module { get; set; }
    }

    public class Modified_User_Link
    {
        public string full_name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    public class _Acl
    {
        public Fields fields { get; set; }
        public string _hash { get; set; }
    }

    public class Fields
    {
        public Pwd_Last_Changed pwd_last_changed { get; set; }
        public Last_Login last_login { get; set; }
    }

    public class Pwd_Last_Changed
    {
        public string write { get; set; }
        public string create { get; set; }
    }

    public class Last_Login
    {
        public string write { get; set; }
        public string create { get; set; }
    }

    public class Created_By_Link
    {
        public string full_name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl1
    //{
    //    public Fields1 fields { get; set; }
    //    public string _hash { get; set; }
    //}

    //public class Fields1
    //{
    //    public Pwd_Last_Changed1 pwd_last_changed { get; set; }
    //    public Last_Login1 last_login { get; set; }
    //}

    public class Pwd_Last_Changed1
    {
        public string write { get; set; }
        public string create { get; set; }
    }

    public class Last_Login1
    {
        public string write { get; set; }
        public string create { get; set; }
    }

    //public class Accounts
    //{
    //    public string name { get; set; }
    //    public string id { get; set; }
    //    public _Acl _acl { get; set; }
    //}

    //public class _Acl2
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Opportunities
    {
        public string id { get; set; }
    }

    public class Reports_To_Link
    {
        public string name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl3
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Business_Centers
    {
        public string name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl4
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Campaign_Contacts
    {
        public string name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl5
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Calls
    {
        public string id { get; set; }
    }

    public class Meetings
    {
        public string id { get; set; }
    }

    public class Assigned_User_Link
    {
        public string full_name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl6
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Team_Count_Link
    {
        public string team_count { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl7
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    public class Dri_Workflow_Template_Link
    {
        public string name { get; set; }
        public string id { get; set; }
        //public _Acl _acl { get; set; }
    }

    //public class _Acl8
    //{
    //    public object[] fields { get; set; }
    //    public string _hash { get; set; }
    //}

    //public class _Acl9
    //{
    //    public Fields2 fields { get; set; }
    //}

    

    //public class Team_Name
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string name_2 { get; set; }
    //    public bool primary { get; set; }
    //    public bool selected { get; set; }
    //}

}
