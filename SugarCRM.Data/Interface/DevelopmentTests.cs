using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SugarCRM.Data.Models;

namespace SugarCRM.Data.Interface
{
    public class DevelopmentTests
    {
        // Example development test running Connection Validation
        public static async Task SugarCRM_Wrapper_ValidateConnection(Integration.Abstract.Connection connection)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;
            var connectionResponse = wrapper.EstablishConnection(conn, wrapper._SugarCRMSettings);
            var response = await wrapper.ValidateConnection();

            // Test with successful and invalid credentials.
            // Are you handling Error responses correctly?
        }

        // Example development test running from your DataModel events
        public static async Task SugarCRM_Template_FromiPaaS_Get(Integration.Abstract.Connection connection)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;
            object _id = new object();

            Account DevTest1 = new Account();
            DevTest1.Id = "9632ba9a-4aa6-11ef-ac10-068962c7e2c7";
            // set other properties for DevTest1
            // set your debug breakpoints in here and step through after executing your DevelopmentTest

            var response = await DevTest1.Get(wrapper, DevTest1.Id);

            // Check your response status.  Did everything go OK?
        }

        public static async Task SugarCRM_Template_FromiPaaS_PostAccount(Integration.Abstract.Connection connection)
        {
            // Confirm that an Customer Posted to Clover is successfully received.
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            SugarCRM.Data.Models.Account testAccount = new SugarCRM.Data.Models.Account();
            testAccount.Name = "Shailendra Thakur";
            testAccount.Description = "This potential customer is a referral from Union Bank (Shailendra Thakur). changed for testing purposes.";
            testAccount.Business_Center_Name = "British scientist, theory of evolution";
            testAccount.Email1 = "peggycupcake@hotmail.com";

            //SugarCRM.Data.Models.Account address1 = new Integration.DataModels.CustomerAddress();

            testAccount.Billing_Address_Street = "422 E 19th Ave";
            testAccount.Billing_Address_Street_2 = "Street No: 2";
            testAccount.Billing_Address_Street_3 = "ABC Tower";
            testAccount.Billing_Address_City = "Philadelphia";
            testAccount.Billing_Address_State = "Pennsylvania";
            testAccount.Billing_Address_PostalCode = "19123";
            testAccount.Billing_Address_Country = "US";

            testAccount.Shipping_Address_Street = "Shipping 422 E 19th Ave";
            testAccount.Shipping_Address_Street_2 = "Shipping Street No: 2";
            testAccount.Shipping_Address_Street_3 = "Shipping ABC Tower";
            testAccount.Shipping_Address_City = "Philadelphia";
            testAccount.Shipping_Address_State = "Pennsylvania";
            testAccount.Shipping_Address_PostalCode = "19123";
            testAccount.Shipping_Address_Country = "US";

            if (testAccount.Contacts == null)
                testAccount.Contacts = new List<Contact>();

            testAccount.Contacts.Add(new Contact()
            {
                Name = "Mr. Shailendra Thankur",
                Description = "Test data from Utility from iPaaS to SugarCRM description",
                Full_Name = "Mr. Shailendra Kumar",
                Title = "Marketing Assistant",
                Phone_Home = "+1-907-411-1995",
                Phone_Mobile = "+1-242-134-4218",
                Phone_Work = "+1-851-117-7116",
                Portal_Name = "ShailendrJoeshTesting" + System.DateTime.Now.ToString(),
                Portal_Active = true,
                Preferred_Language = "en_us",
                Business_Center_Name = "APAC Business Center",
                Business_Center_Id = "990751e6-8831-11e9-8e6f-069335ab1e28",
                Email1 = "anna.bishop@hotmail.com",
                First_Name = "Shailendra",
                Last_Name = "Thankur",
                _Module = "Contacts"
            });

            var tmp = await testAccount.Create(wrapper);
        }


        // Example development test running from your DataModel events
        public static async Task SugarCRM_Template_FromiPaaS_Create(Integration.Abstract.Connection connection)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            DataModels.TemplateModel DevTest1 = new DataModels.TemplateModel();
            DevTest1.Id = 19;
            // set other properties for DevTest1
            // set your debug breakpoints in here and step through after executing your DevelopmentTest

            var response = await DevTest1.Create(wrapper);

            // Check your response status.  Did everything go OK?
        }

        // Example development test running from your DataModel events
        public static async Task SugarCRM_Template_FromiPaaS_WebHookCreate(Integration.Abstract.Connection connection)
        {
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            TranslationUtilities DevTest1 = new TranslationUtilities();
            var output = DevTest1.UpdateWebhookSubscriptionAsync(conn, "Account", true);
            Console.WriteLine(output);
            // Check your response status.  Did everything go OK?
        }
        /*
         * 
        // Example Development Test Structure for Certification
        // Name should be the SugarCRMName_MappingCollectionType_Direction_EventType
        public static async Task MeetHue_Transaction_FromiPaaS_Update(Integration.Abstract.Connection connection)
        {
            // Below is a Test Scenario to turn on a Phillips Hue Light named "Mood Light"
            var conn = (Connection)connection;
            var wrapper = conn.CallWrapper;

            // Development Tests should start with datamodels that were registered in Interface.Metadata
            // Each field in the subscription mappings for this SugarCRM should be represented below setting a value to the corresponding property.
            DataModels.HueAction TestLightAction = new DataModels.HueAction();

            // Highlights of the test
            // 1) Demonstrate how a Built-In Conversion function can be applied in the mappings

            TestLightAction.EventType = DataModels.EventType.Light;
            TestLightAction.SearchName = "Mood Light";
            TestLightAction.LightState = ConversionFunctions.FlashRed();

            await TestLightAction.Update(wrapper);

            // In Comments: Describe the expected outcome and how it can be evidenced
            // The light on my Hue Account named "Mood Light" will have a changed lightstate. 
            // This can be evidenced by camera or by accessing the MeetHue API using the subscription credentials directly.
            // To access it directly, we will make a call to https://api.meethue.com/bridge/{{bridge}}/lights
            // and verify the response.  The response should look like the following.  "Mood Light" is "3" and state.on will equal true afterwards.

            //"3": {
            //    "state": {
            //        "on": true,
            //        "bri": 254,
            //        "hue": 63252,
            //        "sat": 249,
            //        "effect": "none",
            //        "xy": [
            //            0.6616,
            //            0.2828
            //                ],
            //        "alert": "lselect",
            //        "colormode": "hs",
            //        "mode": "homeautomation",
            //        "reachable": true
            //            },
            //    "swupdate": {
            //                "state": "noupdates",
            //        "lastinstall": "2021-10-22T18:36:44"
            //    },
            //    "type": "Color light",
            //    "name": "Mood Light",
            //    "modelid": "LLC011",
            //    "manufacturername": "Signify Netherlands B.V.",
            //    "productname": "Hue bloom",
            //    "capabilities": {
            //                "certified": true,
            //        "control": {
            //                    "mindimlevel": 10000,
            //            "maxlumen": 120,
            //            "colorgamuttype": "A",
            //            "colorgamut": [
            //                [
            //                    0.704,
            //                    0.296
            //                ],
            //                [
            //                    0.2151,
            //                    0.7106
            //                ],
            //                [
            //                    0.138,
            //                    0.08
            //                ]
            //            ]
            //        },
            //        "streaming": {
            //                    "renderer": true,
            //            "proxy": false
            //        }
            //            },
            //    "config": {
            //                "archetype": "huebloom",
            //        "function": "decorative",
            //        "direction": "upwards",
            //        "startup": {
            //                    "mode": "custom",
            //            "configured": true,
            //            "customsettings": {
            //                        "bri": 254,
            //                "xy": [
            //                    0.202,
            //                    0.5619
            //                ]
            //            }
            //                }
            //            },
            //    "uniqueid": "00:17:88:01:00:1c:76:4a-0b",
            //    "swversion": "67.91.1"
            //}

        }
        */

    }

}

