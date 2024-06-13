using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using TingenNetsmartServices.UAT_NtstUserManagementWebService;

namespace Outpost31.Module.Testing.NtstWebService
{
    public static class UserMgmt
    {
        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static string DoesExist(TingenSession tnSession)
        {
            LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);
            //TingenNetsmartServices.UAT.UserManagement.GetResponse(tnSession.AvData.AvatarSystemCode, "doesUserExist", tnSession.NtstWebServiceSecurity.WebServiceUser, tnSession.NtstWebServiceSecurity.WebServicePassword, tnSession.AvData.AvatarUserName);

            TingenNetsmartServices.UAT.UserManagement.GetResponse("UAT", "doesUserExist",  "TINGENWEBSERVICE", "V4nH4len", "CBANWARTH");

            LogEvent.Trace(2, AssemblyName, tnSession.TraceInfo);


            //webServiceResponse = new UAT_NtstUserManagementWebService.WebServicesSoapClient().DoesUserExist("UAT", "TINGENWEBSERVICE", "V4nH4len", avatarUserName).Message;

            //TingenNetsmartServices.UAT.UserManagement.GetResponse(tnSession.AvData.AvatarSystemCode, "doesUserExist", tnSession.NtstWebServiceSecurity.WebServiceUser, tnSession.NtstWebServiceSecurity.WebServicePassword, tnSession.AvData.AvatarUserName);

            return "yes";
        }
    }
}
