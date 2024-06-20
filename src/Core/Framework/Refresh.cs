// u240620.1331

using Outpost31.Core.Session;

namespace Outpost31.Core.Framework
{
    /// <summary>Refresh the Tingen directory structure.</summary>
    public static class Refresh
    {
        /// <summary>Refresh the Tingen directory structure when Tingen is disabled.</summary>
        /// <remarks>
        ///  <para>
        ///   - If Tingen is disabled, might as well update the service status files.
        ///  </para>
        /// </remarks>
        /// <param name="tnSession">The Tingen Session object</param>
        public static void RefreshOnDisable(TingenSession tnSession)
        {
            /*[1]*/
            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }

        /*[2]*/

        /// <summary>Refresh the Tingen directory structure when Tingen is in an unknown state.</summary>
        public static void RefreshOnUnknown(TingenSession tnSession)
        {
            /*[1]*/
            /*[3]*/
            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

[1] Don't pass the entire session object?
[2] When Tingen is re-enabled, automate the process of refreshing the status files.
[3] When unknown, status info is refreshed and there is a message. Should there be a message, and if so, what should that message be?

*/