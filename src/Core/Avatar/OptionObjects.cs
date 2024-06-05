// u240605.0913

using System.Reflection;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for OptionObjects.</summary>
    public static class OptionObjects
    {
        /// <summary>Return an unmodified OptionObject to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <paramref name="SentObject"/> is cloned to the <see cref="ReturnObject"/>.<br/>
        ///   - Since the <paramref name="SentObject"/> is never modified, the <see cref="ReturnObject"/> is an exact copy of the original data.<br/>
        ///  </para>
        /// </remarks>
        public static void ReturnUnmodified(TingenSession tnSession)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            tnSession.AvatarData.ReturnObject = tnSession.AvatarData.SentObject.Clone();
        }
    }
}

/*

Development notes
-----------------

- Verify trace logs cannot be used in ReturnUnmodified()
- Limit what is passed to ReturnUnmodified()

*/