using Outpost31.Core.Session;

namespace Outpost31.Core.TheOptionObject
{
    public static class TheReturnOptionObject
    {
        public static void NoWork(TingenSession tnSession)
        {
            tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject();

        }

        public static void Error1(TingenSession tnSession, string errorMessage)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.TheOptionObject.TheReturnOptionObject()]"); /* <- For development use only */

            tnSession.AvComponents.ReturnOptionObject = tnSession.AvComponents.SentOptionObject.ToReturnOptionObject(1, errorMessage);
        }
    }
}
