// u240530.1213

using System.IO;
using Outpost31.Core.Session;

namespace Outpost31.Module.OpenIncident.Action
{
    /// <summary>VerifyAuthor command.</summary>
    public static partial class VerifyAuthor
    {
        /// <summary>Verify the Avatar user is the same as the original author.</summary>
        /// <param name="tnSession"></param>
        public static void IsOriginal(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.Action.VerifyAuthor.SaveOriginal()]"); /* <- For development use only */

            var originalAuthor = File.ReadAllText($@"{tnSession.TnFramework.TemporaryPath}\{tnSession.AvComponents.SentOptionObject.OptionUserId}-verifyauthor.data");
            var currentAuthor = tnSession.AvComponents.SentOptionObject.GetFieldValue("32");

            if (originalAuthor == currentAuthor)
            {
                //Core.TheOptionObject.TheReturnOptionObject.NoWork(tnSession);
                tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(0, "Success");
                //tnSession.AvComponents.SentOptionObject.OptionUserId = "true";
            }
            else
            {
                tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(1, "Bad!");
                //Core.TheOptionObject.TheReturnOptionObject.Error1(tnSession, "Author is not original.");
                //tnSession.AvComponents.SentOptionObject.OptionUserId = "false";
            }
        }

        /// <summary>Save the original author.</summary>
        public static void SaveOriginal(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Module.OpenIncident.Action.VerifyAuthor.IsOriginal()]"); /* <- For development use only */

            var currentAvatarUser = tnSession.AvComponents.SentOptionObject.OptionUserId;
            var originalAuthor    = tnSession.AvComponents.SentOptionObject.GetFieldValue("32");

            var filePath = $@"{tnSession.TnFramework.TemporaryPath}\{currentAvatarUser}-verifyauthor.data";

            Outpost31.Module.Common.FieldOperation.SaveValue(originalAuthor, filePath);
        }
    }
}