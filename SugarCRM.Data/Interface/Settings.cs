using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration.Abstract.Helpers;
using Integration.Abstract.Model;

namespace SugarCRM.Data.Interface
{
    // Whenever an SugarCRM is subscribed to, information that is unique to the customer may be needed by the SugarCRM. 
    // Settings defined below will be populated by iPaaS.com at runtime with the corresponding "Preset" value saved by the subscriber.
    // GetSetting method will collect the Preset value defined in the SugarCRM console or in MetaData.cs\MetaData\GetPresets().
    public class Settings : Integration.Abstract.Settings
    {
        public string Url { get { return this.GetSetting("API URL", required: true); } }
        //public string Url { get { return this.GetSetting("https://sg-driscollpocv2.demo.sugarcrm.com/rest/v11/Accounts/9632ba9a-4aa6-11ef-ac10-068962c7e2c7", required: true); } }
        public string APIUser { get { return this.GetSetting("API User", required: true); } }
        //public string APIUser { get { return this.GetSetting("admin", required: true); } }
        public string APIPassword { get { return this.GetSetting("API Password", required: true); } }
        //public string APIPassword { get { return this.GetSetting("eVm!iI4R07TlDF!MB,NY", required: true); } }

       //public PersistentDataHandler PersistentDataHandler { get; set; }
        
        public string IPaaSApi_EmployeeUrl 
        { 
            get 
                {   //Depending on the environment, the employee url might be under one of two listings 
                    var retVal = GetSetting("Employees_URL");
                    if(string.IsNullOrEmpty(retVal))
                        retVal = GetSetting("3D4X_URL");
                    return retVal;
                } 
        }

        public string IPaaSApi_MessageUrl
        {
            get
            {   //Depending on the environment, the employee url might be under one of two listings 
                var retVal = GetSetting("Messagess_URL");
                if (string.IsNullOrEmpty(retVal))
                    retVal = GetSetting("KUP24_URL");
                return retVal;
            }
        }

        public string IPaaSApi_CustomerUrl
        {
            get
            {   //Depending on the environment, the customer url might be under one of two listings 
                var retVal = GetSetting("Customer_URL");
                if (string.IsNullOrEmpty(retVal))
                    retVal = GetSetting("3D4X_URL");
                return retVal;
            }
        }
    }
}
