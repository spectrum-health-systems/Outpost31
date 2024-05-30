// u240530.1552

using Outpost31.Core.Session;

namespace Outpost31.Module.Common.Action
{
    /// <summary>Contains Field-specific logic (see Field.Properties.cs for more information about this class).</summary>
    public static partial class Field
    {
        public static void ParseAction(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.Common.Action.Field.ParseAction()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptAction)
            {
                case "get":
                    GetField(tnSession);
                    break;

                case "set":
                    SetField(tnSession);
                    break;

                default:
                    break;
            }
        }
    }
}
