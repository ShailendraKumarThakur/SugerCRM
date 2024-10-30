using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarCRM.Data.Models
{
    public class WebLogicHook
    {
        [JsonProperty("name")]
        public string Name { get; set; }
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
        [JsonProperty("webhook_target_module")]
        public string Webhook_Target_Module { get; set; }
        [JsonProperty("request_method")]
        public string Request_Method { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("trigger_event")]
        public string Trigger_Event { get; set; }
        [JsonProperty("following")]
        public bool Following { get; set; }
        [JsonProperty("my_favorite")]
        public bool My_Favorite { get; set; }
        [JsonProperty("locked_fields")]
        public object[] Locked_Ffields { get; set; }
        [JsonProperty("sync_key")]
        public string Sync_Key { get; set; }
        [JsonProperty("_acl")]
        public _Acl _Acl { get; set; }
        [JsonProperty("_module")]
        public string _Module { get; set; }
    }       

}
