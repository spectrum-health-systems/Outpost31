// u240530.1114

using System.Collections.Generic;
using Outpost31.Core.Avatar;
using Outpost31.Core.Framework;

namespace Outpost31.Core.Session
{
    /// <summary>Contains Tingen Session logic (see TingenSession.Properties.cs for more information about this class).</summary>
    public partial class TingenSession
    {
        /// <summary>Determines what Tingen does, if anything.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public string TingenMode { get; set; }

        /// <summary>The current Tingen version.</summary>
        /// <remarks>
        ///  <para>
        ///   This is the first component of the configuration TingenVersionBuild setting<br/><br/>.
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public string TingenVersion { get; set; }

        /// <summary>The current Tingen build.</summary>
        /// <remarks>
        ///  <para>
        ///   This is the second component of the configuration TingenVersionBuild setting<br/><br/>.
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public string TingenBuild { get; set; }

        /// <summary>The session timestamp.</summary>
        public string SessionTimestamp { get; set; }

        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public string AvatarSystemCode { get; set; }

        /// <summary>The log mode Tingen will use.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public int LogMode { get; set; }

        /// <summary>The delay between creating logs.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public int LogDelay { get; set; }

        /// <summary>Determines if the Admin Module is enabled.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public bool ModAdminEnabled { get; set; }

        /// <summary>The list of authrorized users for the Admin Module.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenConfiguration.Properties.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public List<string> ModAdminWhitelist { get; set; }

        /// <summary>Tingen Framework information.</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public TingenFramework TnFramework { get; set; }

        /// <summary>Avatar components .</summary>
        /// <remarks>
        ///  <para>
        ///   See <b>Outpost31.Core.Configuration.TingenFramework.cs</b> for more information.
        ///  </para>
        /// </remarks>
        public AvatarComponents AvComponents { get; set; }
    }
}
