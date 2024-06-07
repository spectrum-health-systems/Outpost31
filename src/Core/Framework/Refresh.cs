using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    public static class Refresh
    {
        public static void RefreshOnDisable(TingenSession tnSession)
        {
            /* If Tingen is disabled, we should update the service status files so the necessary users are notified. When
             * Tingen is re-enabled, the service status files will need to be manually updated using the Admin Module.
             */

            Outpost31.Core.Framework.Maintenance.VerifyFrameworkStructure(tnSession);
            Outpost31.Module.Admin.Service.Status.UpdateAll(tnSession);
        }


        public static void RefreshOnDevelopment(TingenSession tnSession)
        {
            Outpost31.Core.Framework.Maintenance.RefreshDirectory(tnSession.TnPath.Tingen.Primeval);
            Outpost31.Core.Framework.Maintenance.RefreshDirectory(tnSession.TnPath.SystemCode.Sessions);
        }
    }
}
