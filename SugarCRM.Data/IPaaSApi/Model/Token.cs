using System;
using System.Collections.Generic;
using System.Text;

namespace SugarCRM.Data.IPaaSApi.Model
{
    public class Token
    {    
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        public int refresh_expires_in { get; set; }
        public string download_token { get; set; }
    }
}
