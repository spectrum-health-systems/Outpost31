// u240530.1242

using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident.Action
{
    /// <summary>Logic for the <b>VerifyAuthor</b> Command of the OpenIncident Module.</summary>
    /// <remarks>
    ///   <para>
    ///    This class contains the methods that does things with the "VerifyAuthor" Command.
    ///    The Service Command is parsed in the <b>ParseScriptCommand.cs</b> file.
    ///  </para>
    /// </remarks>
    public static partial class VerifyAuthor
    {
        /// <summary>Parses the script Action for the OpenIncident Module's "VerifyAuthor" Command.</summary>
        /// <remarks>
        ///  <para>
        ///   Valid VerifyAuthor Actions:
        ///   <list type="table">
        ///     <item>
        ///      <term>IsOriginal</term>
        ///      <description>Verify the Avatar user is the original author of the Open Incident.</description>
        ///     </item>
        ///     <item>
        ///      <term>SaveOriginal</term>
        ///      <description>Save the value in the "Person Completing Incident Form" field to a temporary file.</description>
        ///     </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public static void ParseAction(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.Action.VerifyAuthor.ParseAction()]"); /* <- For development use only */

            switch (tnSession.AvComponents.ScriptAction)
            {
                case "isoriginal":
                    IsOriginal(tnSession);
                    break;

                case "saveoriginal":
                    SaveOriginal(tnSession);
                    break;

                default:
                    break;
            }

        }
    }
}
