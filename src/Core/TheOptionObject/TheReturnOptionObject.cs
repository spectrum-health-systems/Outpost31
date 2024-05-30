// u240530.1107

using Outpost31.Core.Session;

namespace Outpost31.Core.TheOptionObject
{
    /// <summary>Contains the logic for the ReturnOptionObject.</summary>
    public static class TheReturnOptionObject
    {
        /// <summary>No work is done.</summary>
        /// <param name="tnSession"></param>
        public static void NoWork(TingenSession tnSession)
        {
            tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject();

        }

        /// <summary>Error1</summary>
        /// <param name="tnSession"></param>
        /// <param name="errorMessage"></param>
        public static void Error1(TingenSession tnSession, string errorMessage)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.TheOptionObject.TheReturnOptionObject()]"); /* <- For development use only */

            tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(1, errorMessage);
        }
    }
}