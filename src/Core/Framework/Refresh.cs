// u240607.1017

using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    public static class Refresh
    {
        /// <summary>Refresh the Tingen directory structure when Tingen is disabled.</summary>
        /// <remarks>
        /// If Tingen is disabled, we should update the service status files so the necessary users are notified. When <br/>
        /// Tingen is re-enabled, the service status files will need to be manually updated using the Admin Module.
        /// </remarks>
        /// <param name="tnSession"></param>
        public static void RefreshOnDisable(TingenSession tnSession)
        {
            Maintenance.VerifyFrameworkStructure(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }

        public static void RefreshOnUnknown(TingenSession tnSession)
        {
            Maintenance.VerifyFrameworkStructure(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }

        public static void RefreshOnDevelopment(TingenSession tnSession)
        {
            Maintenance.RefreshDirectory(tnSession.TnPath.Tingen.Primeval);
            Maintenance.RefreshDirectory(tnSession.TnPath.SystemCode.Sessions);
        }
    }
}

/*

-----------------
Development notes
-----------------

*/