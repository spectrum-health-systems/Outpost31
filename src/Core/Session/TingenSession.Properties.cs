// u240525.1402

using Outpost31.Core.Avatar;
using Outpost31.Core.Framework;

namespace Outpost31.Core.Session
{
    public partial class TingenSession
    {
        public string TingenMode { get; set; }
        public string TingenVersion { get; set; }
        public string TingenBuild { get; set; }
        public string SessionTimestamp { get; set; }
        public string AvatarSystemCode { get; set; }
        public int LogMode { get; set; }
        public int LogDelay { get; set; }
        public int DebugglerMode { get; set; }
        public TingenFramework TnFramework { get; set; }
        public AvatarData AvComponents { get; set; }
        //public TingenModules AbModules { get; set; }
    }

    //public class AvatarComponents
    //{
    //    public string AvatarSystemCode { get; set; }
    //    public string SentScriptParameter { get; set; }
    //    public string ScriptModule { get; set; }
    //    public string ScriptCommand { get; set; }
    //    public string ScriptAction { get; set; }
    //    public string ScriptOption { get; set; }
    //    public OptionObject2015 SentOptionObject { get; set; }
    //    public OptionObject2015 WorkOptionObject { get; set; }
    //    public OptionObject2015 ReturnOptionObject { get; set; }
    //}
}
