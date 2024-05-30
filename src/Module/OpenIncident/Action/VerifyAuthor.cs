// u240528.1744

using System.IO;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident.Action
{
    public static partial class VerifyAuthor
    {
        public static void SaveOriginal(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.Action.VerifyAuthor.IsOriginal()]"); /* <- For development use only */

            var currentAvatarUser = tnSession.AvComponents.SentOptionObject.OptionUserId;
            var originalAuthor    = tnSession.AvComponents.SentOptionObject.GetFieldValue("32");

            var filePath = $@"{tnSession.TnFramework.TemporaryPath}\{currentAvatarUser}-verifyauthor.data";

            Outpost31.Module.Common.FieldOperation.SaveValue(originalAuthor, filePath);
        }


        public static void IsOriginal(TingenSession tnSession)
        {
            Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.Action.VerifyAuthor.SaveOriginal()]"); /* <- For development use only */

            var originalAuthor = File.ReadAllText($@"{tnSession.TnFramework.TemporaryPath}\{tnSession.AvComponents.SentOptionObject.OptionUserId}-verifyauthor.data");
            var currentAuthor = tnSession.AvComponents.SentOptionObject.GetFieldValue("32");

            if (originalAuthor == currentAuthor)
            {
                Outpost31.Core.Debuggler.Primeval.Log($"[TRUE]");
                //Core.TheOptionObject.TheReturnOptionObject.NoWork(tnSession);
                tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(0, "Success");
                //tnSession.AvComponents.SentOptionObject.OptionUserId = "true";
            }
            else
            {
                Outpost31.Core.Debuggler.Primeval.Log($"[FALSE]");

                tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(1, "Bad!");
                //Core.TheOptionObject.TheReturnOptionObject.Error1(tnSession, "Author is not original.");
                //tnSession.AvComponents.SentOptionObject.OptionUserId = "false";
            }
        }
    }
}
