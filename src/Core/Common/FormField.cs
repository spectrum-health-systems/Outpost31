// u240528.1744

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outpost31.Module.Common
{
    public static class FormField
    {
        public static bool Compare(string fieldId01, string fieldId02)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.FormField.Compare()]"); /* <- For development use only */

            if (fieldId01 == fieldId02)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveValue(string value, string filePath)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Common.FormField.SaveValue()]"); /* <- For development use only */

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            File.WriteAllText(filePath, value);

            Outpost31.Core.Debuggler.Primeval.Log($"[E1]");
            Environment.Exit(0);
            Outpost31.Core.Debuggler.Primeval.Log($"[E2]");


        }
    }
}
