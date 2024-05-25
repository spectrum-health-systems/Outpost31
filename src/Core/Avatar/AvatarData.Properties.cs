// u240525.1402

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{

    public partial class AvatarData
    {
        public string SentScriptParameter { get; set; }
        public string ScriptModule { get; set; }
        public string ScriptCommand { get; set; }
        public string ScriptAction { get; set; }
        public string ScriptOption { get; set; }
        public OptionObject2015 SentOptionObject { get; set; }
        public OptionObject2015 WorkOptionObject { get; set; }
        public OptionObject2015 ReturnOptionObject { get; set; }
    }
}