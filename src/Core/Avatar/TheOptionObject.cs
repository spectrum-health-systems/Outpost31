// u240531.1336

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpost31.Core.Session;

namespace Outpost31.Core.Avatar
{
    public static class TheOptionObject
    {
        /// <summary>Clones the SentOptionObject to the ReturnOptionObject (so, no work).</summary>
        public static void ReturnClonedSent(TingenSession tnSession)
        {
            tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.Clone();
        }



        /// <summary>No work is done.</summary>
        /// <param name="tnSession"></param>
        public static void NoWork(TingenSession tnSession)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.TheOptionObject.TheReturnOptionObject.NoWork()]"); /* <- For development use only */

            //tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.ToReturnOptionObject();

        }

        /// <summary>Error1</summary>
        /// <param name="tnSession"></param>
        /// <param name="errorMessage"></param>
        public static void Error1(TingenSession tnSession, string errorMessage)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.TheOptionObject.TheReturnOptionObject()]"); /* <- For development use only */

            //tnSession.AvData.ReturnOptionObject = tnSession.AvData.SentOptionObject.ToReturnOptionObject(1, errorMessage);
        }
    }
}
