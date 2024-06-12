// u240607.1005

using Outpost31.Core.Session;

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
        public static void ReturnUnmodifiedObject(TingenSession tnSession)
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone();
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