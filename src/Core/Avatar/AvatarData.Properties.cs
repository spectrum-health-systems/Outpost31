// u240530.0621

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for Avatar-specific data.</summary>
    /// <remarks>
    ///  <para>
    ///   Properties for the Avatar data are located in <b>AvatarData.Properties.cs.</b>
    ///  </para>
    ///  <para>
    ///   Only data sent directly from Avatar, and data derived from the sent data, should be here:
    ///   <list type="bullet">
    ///    <item>The sentOptionObject (and the workOptionObject and returnOptionObject)</item>
    ///    <item>The sentScriptParameter (and its individual components)</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public partial class AvatarData
    {
        /// <summary>The original ScriptParameter sent from Avatar.</summary>
        public string SentScriptParameter { get; set; }

        /// <summary>The <i>Module</i> component of the ScriptParameter.</summary>
        public string ScriptModule { get; set; }

        /// <summary>The <i>Command</i> component of the ScriptParameter.</summary>
        public string ScriptCommand { get; set; }

        /// <summary>The <i>Action</i> component of the ScriptParameter.</summary>
        public string ScriptAction { get; set; }

        /// <summary>The <i>Option</i> component of the ScriptParameter.</summary>
        public string ScriptOption { get; set; }

        /// <summary>The original OptionObject sent from Avatar.</summary>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that will be used to do the work during the session.</summary>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject that will be returned to Avatar.</summary>
        public OptionObject2015 ReturnOptionObject { get; set; }
    }
}