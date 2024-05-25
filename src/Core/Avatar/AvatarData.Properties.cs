// u240525.1402

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Properties for Avatar data.</summary>
    /// <remarks>
    ///     - Logic for the Avatar data is located in AvatarData.cs.
    /// </remarks>
    public partial class AvatarData
    {
        /// <summary>The ScriptParameter sent from Avatar.</summary>
        public string SentScriptParameter { get; set; }

        /// <summary>The <i>Module</i> component of the ScriptParameter.</summary>
        public string ScriptModule { get; set; }

        /// <summary>The <i>Command</i> component of the ScriptParameter.</summary>
        public string ScriptCommand { get; set; }

        /// <summary>The <i>Action</i> component of the ScriptParameter.</summary>
        public string ScriptAction { get; set; }

        /// <summary>The <i>Option</i> component of the ScriptParameter.</summary>
        public string ScriptOption { get; set; }

        /// <summary>The OptionObject sent from Avatar.</summary>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that will be used to do the work this session.</summary>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject that will be returned to Avatar.</summary>
        public OptionObject2015 ReturnOptionObject { get; set; }
    }
}