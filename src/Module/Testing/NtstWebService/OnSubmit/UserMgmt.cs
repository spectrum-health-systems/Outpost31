using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Session;

namespace Outpost31.Module.Testing.NtstWebService.OnSubmit
{
    public static class UserMgmt
    {
        public static string DoesExist(TingenSession tnSession)
        {
            TingenNetsmartServices.UAT.UserManagement.GetResponse(tnSession.AvData.AvatarSystemCode, "doesUserExist", tnSession.NtstWebServiceSecurity.WebServiceUser, tnSession.NtstWebServiceSecurity.WebServicePassword, tnSession.AvData.AvatarUserName);

            return "yes";
        }

    }
}
