// u240709.0000_code
// u241021_documentation

using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>Refresh the Tingen directory structure.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Framework.Refresh_doc.xml' path='Outpost31.Core.Framework.Refresh/Type[@name="Class"]/Refresh/*'/>
    public static class Refresh
    {
        /* [DN01] */
        /// <summary>Refresh the Tingen directory structure when Tingen is disabled.</summary>
        /// <param name="tnSession">The Tingen Session object</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Refresh_doc.xml' path='Outpost31.Core.Framework.Refresh/Type[@name="Method"]/RefreshOnDisable/*'/>
        public static void RefreshOnDisable(TingenSession tnSession)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }

        /* [DN01] */
        /// <summary>Refresh the Tingen directory structure when Tingen is in an unknown state.</summary>
        /// <param name="tnSession">The Tingen Session object</param>
        /// <include file='XmlDoc/Outpost31.Core.Framework.Refresh_doc.xml' path='Outpost31.Core.Framework.Refresh/Type[@name="Method"]/RefreshOnUnknown/*'/>
        public static void RefreshOnUnknown(TingenSession tnSession)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
             */

            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }
    }
}

/*
=================
DEVELOPMENT NOTES
=================

-----------------
[DN01] 241118
-----------------
Combine these two methods?


*/