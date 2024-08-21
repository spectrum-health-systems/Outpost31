// u240709.0000_code
// u240709.0000_documentation

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
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }

        /// <summary>Refresh the Tingen directory structure when Tingen is in an unknown state.</summary>
        public static void RefreshOnUnknown(TingenSession tnSession)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            Maintenance.VerifyFramework(tnSession);
            Module.Admin.Service.Status.UpdateAll(tnSession);
        }
    }
}