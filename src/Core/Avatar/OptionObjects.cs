// u240607.1005

using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for OptionObjects.</summary>
    public static class OptionObjects
    {
        /// <summary>Return an unmodified OptionObject to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <paramref name="SentOptionObject"/> is cloned to the <paramref name="ReturnOptionObject"/>.<br/>
        ///   - Since the <paramref name="SentOptionObject"/> is never modified, the <paramref name="ReturnOptionObject"/> is an exact copy of the original data.<br/>
        ///   - The <paramref name="ReturnOptionObject"/> is still not formatted for Avatar, which is done at the end of Tingen.asmx.cs<br/>
        ///  </para>
        /// </remarks>
        public static void ReturnClone(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.None, "");
        }

        // Error 0
        public static void ReturnSuccess(TingenSession tnSession)
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.None, "");
        }

        // Error 1
        public static void ReturnError(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.Error, errorMessage);
        }

        // Error 2
        public static void ReturnOkCancel(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OkCancel, errorMessage);
        }

        // Error 3
        public static void ReturnInfo(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.Info, errorMessage);
        }

        // Error 4
        public static void ReturnYesNo(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.YesNo, errorMessage);
        }

        // Error 5
        public static void ReturnOpenUrl(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OpenUrl, errorMessage);
        }

        // Error 6
        public static void ReturnOpenForm(TingenSession tnSession, string errorMessage = "")
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.WorkOptionObject.Clone();
            tnSession.AvData.ReturnOptionObject.ToReturnOptionObject(ErrorCode.OpenForm, errorMessage);
        }
    }
}

/*

-----------------
Development notes
-----------------

- Verify trace logs cannot be used in ReturnUnmodified()
- Limit what is passed to ReturnUnmodified(), not the entire TingenSession object

*/