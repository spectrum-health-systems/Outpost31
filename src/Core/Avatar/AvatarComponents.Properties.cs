// u240530.0621

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for Avatar-specific data.</summary>
    /// <remarks>
    ///  <para>
    ///   Properties for the AvatarData.cs are located in <b>AvatarData.Properties.cs.</b>
    ///  </para>
    ///  <para>
    ///   Only data sent directly from Avatar, and data derived from the sent data, should be here:
    ///   <list type="bullet">
    ///    <item>The sentOptionObject (and the derived workOptionObject and returnOptionObject)</item>
    ///    <item>The sentScriptParameter (and the derived individual components)</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public partial class AvatarComponents
    {
        /// <summary>The original ScriptParameter sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   The ScriptParameter is a "-" delimited string that is sent from Avatar and contains information that tells Tingen what it
        ///   needs to do.<br/><br/>
        ///   The ScriptParameter syntax is: <c>Module-Command-Action-Option</c> (e.g., "<c>Admin-Service-Status-Update</c>").
        ///  </para>
        /// </remarks>
        public string SentScriptParameter { get; set; }

        /// <summary>The <i>Module</i> component of the ScriptParameter.</summary>
        /// <remarks>
        ///  <para>
        ///   The <i>Module</i> component determines which Tingen Module will do the work during the session. (e.g., "<c>Admin</c>")
        ///  </para>
        /// </remarks>
        public string ScriptModule { get; set; }

        /// <summary>The <i>Command</i> component of the ScriptParameter.</summary>
        /// <remarks>
        ///  <para>
        ///   The <i>Command</i> component determines the Command that is being requested (e.g., "<c>Service</c>")
        ///  </para>
        /// </remarks>
        public string ScriptCommand { get; set; }

        /// <summary>The <i>Action</i> component of the ScriptParameter.</summary>
        /// <remarks>
        ///  <para>
        ///   The <i>Action</i> component determines the Action that is being requested (e.g., "<c>Status</c>")
        ///  </para>
        /// </remarks>
        public string ScriptAction { get; set; }

        /// <summary>The <i>Option</i> component of the ScriptParameter.</summary>
        /// <remarks>
        ///  <para>
        ///   The (optional) <i>Option</i> component determins any (optional!) Option for the Action component (e.g., "<c>Update</c>")
        ///  </para>
        /// </remarks>
        public string ScriptOption { get; set; }

        /// <summary>The OptionObject sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   This is the original OptionObject sent from Avatar.<br/><br/>
        ///   This OptionObject should not be modified - work is done with the <paramref name="WorkOptionObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that will be used to do the work during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   This OptionObject is a clone of the <paramref name="SentOptionObject"/> and is used to do the work during the session.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   This OptionObject is a clone of the <paramref name="WorkOptionObject"/>, and contains all of the modifications done during
        ///   the session.<br/><br/>
        ///   This is the OptionObject that will be returned to Avatar.
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnOptionObject { get; set; }
    }
}