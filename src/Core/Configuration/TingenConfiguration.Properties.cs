// u240603.1756

using System.Collections.Generic;

namespace Outpost31.Core.Configuration
{
    /// <summary>Tingen-specific configurations. (see TingenConfiguration.cs for more information about this class).</summary>
    public partial class TingenConfiguration
    {
        /// <summary>Determines what Tingen does, if anything.</summary>
        /// <remarks>
        ///  <para>
        ///   The TingenMode can be:
        ///   <list type="table">
        ///    <item>
        ///     <term>Enabled (default)</term>
        ///     <description>Tingen is enabled, and will do work</description>
        ///    </item>
        ///    <item>
        ///     <term>Disabled</term>
        ///     <description>Tingen is disabled, and will not do any work</description>
        ///    </item>
        ///    <item>
        ///     <term>Development</term>
        ///     <description>Tingen is enabled, and development/debugging data is reset at execution</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   When <i>disabled</i>, Tingen becomes a pass-through, and the sentOptionObject is returned unmodified.<br/><br/>
        ///   Setting the mode to <i>disabled</i> is the equivalent of disabling ScriptLink on every form that uses Tingen.<br/><br/>
        ///   When the mode is set to <i>development</i>, Tingen is enabled and works normally. However,<br/>
        ///   any development-related data, such as debugging logs or testing data, is reset at execution.
        ///  </para>
        /// </remarks>
        public string TingenMode { get; set; }

        /// <summary>The current Tingen version and build.</summary>
        /// <remarks>
        ///  <para>
        ///   The format is <b>%version%-%build%</b> (e.g., <c>24.5.0-240525.1310)</c>
        ///  </para>
        /// </remarks>
        public string TingenVersionBuild { get; set; }

        /// <summary>The root path for Tingen data.</summary>
        /// <remarks>
        ///  <para>
        ///   All non-service Tingen data is located here.<br/><br/>
        ///   The default value is "<c>C:\TingenData\</c>"
        ///  </para>
        /// </remarks>
        public string TingenDataRoot { get; set; }

        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   The Avatar System Code can be one of the following:
        ///   <list type="table">
        ///    <item>
        ///     <term>LIVE</term>
        ///     <description>Tingen will access data in the production environment.</description>
        ///    </item>
        ///    <item>
        ///     <term>UAT</term>
        ///     <description>Tingen will access data in the testing environment.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   The System Code also determines where Tingen data is written (ex: "<c>C:\TingenData\UAT\</c>").
        ///  </para>
        /// </remarks>
        public string AvatarSystemCode { get; set; }

        /// <summary>The Tingen log mode.</summary>
        /// <remarks>
        ///  <para>
        ///   Tingen has a number of log modes, which determine how Tingen logs data.
        ///   <list type="table">
        ///    <item>
        ///     <term>0</term>
        ///     <description>Logging is disabled (no logs are written).</description>
        ///    </item>
        ///    <item>
        ///     <term>1</term>
        ///     <description>Trace logs are created.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   Logs are written to <i>%TingenDataRoot%\%AvatarSystemCode%\Logs</i> (ex: "<c>C:\TingenData\UAT\Logs</c>").
        ///  </para>
        /// </remarks>
        public int TraceLogLevel { get; set; }

        /// <summary>The delay between log writes.</summary>
        /// <remarks>
        ///  <para>
        ///   In some cases, logs may be written to quickly and cause files to be overwritten.<br/>
        ///   By including a short delay, the logs can
        ///   be written in a way that prevents this from happening.<br/><br/>
        ///   The default value is <c>100</c> (milliseconds).
        ///  </para>
        /// </remarks>
        public int TraceLogDelay { get; set; }

        /// <summary>Determines if the Admin Module is enabled.</summary>
        /// <remarks>
        ///  <para>
        ///   <list type="table">
        ///    <item>
        ///     <term>Enabled (default)</term>
        ///     <description>The Admin Module is enabled, and will do work</description>
        ///    </item>
        ///    <item>
        ///     <term>Disabled</term>
        ///     <description>The Admin Module is disabled, and will not do any work.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   When <i>disabled</i>, the Admin Module becomes a pass-through - no work is done, and the sentOptionObject
        ///   is returned unmodified.<br/>
        ///   Setting the mode to <i>disabled</i> is the equivalent of disabling ScriptLink on every form that uses the
        ///   <b>Admin Module</b>.
        ///   The rest of the web service, and Modules that are enabled, will continue to work as normal.
        ///  </para>
        /// </remarks>
        public bool ModAdminEnabled { get; set; }

        /// <summary>The Admin Module user whitelist.</summary>
        /// <remarks>
        ///  <para>
        ///   You can limit which users are allowed to access the Admin Module by including their username in this whitelist.<br/><br/>
        ///   If the whitelist is empty, all users will be allowed to access the Admin Module.<br/><br/>
        ///   When users are not on the whitelist, the Admin Module essentially becomes a pass-through for them.<br/><br/>
        ///   This is useful for testing, or for limiting access to the Admin Module to a select group of users.<br/><br/>
        ///  </para>
        /// </remarks>
        public List<string> ModAdminWhitelist { get; set; }
    }
}