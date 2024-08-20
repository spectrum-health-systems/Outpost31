// u240820.1131_code
// u240820.1131_documentation

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>The Tingen session component that contains Avatar-related data.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="AvatarData"]/AvatarData/*'/>
    public class AvatarData
    {
        /// <summary>The Avatar System Code that Tingen will interface with.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/SystemCode/*'/>
        public string SystemCode { get; set; }

        /// <summary>The original data structure sent from Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/SentOptionObject/*'/>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The original Script Parameter sent from Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/SentScriptParameter/*'/>
        public string SentScriptParameter { get; set; }

        /// <summary>The data structure that (is potentially) modified during a Tingen Session.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/WorkOptionObject/*'/>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The data structure that returned to Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Type[@name="Property"]/ReturnOptionObject/*'/>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData data structure.</summary>
        /// <param name="sentOptionObject">The SentOptionObject data structure sent from Avatar.</param>
        /// <param name="sentScriptParameter">The SentScriptParameter sent from Avatar.</param>
        /// <returns>All of the data/information Tingen needs in order to do work.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Common/Type[@name="Property"]/BuildObject/*'/>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log.
             */

            return new AvatarData
            {
                SystemCode          = "defined-at-runtime-in-Tingen.Runscript()",
                SentOptionObject    = sentOptionObject,
                SentScriptParameter = sentScriptParameter.ToLower(),
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }
    }
}