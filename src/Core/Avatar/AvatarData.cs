// u240818.0908_code
// u240818.0908_documentation

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>The Tingen session component that contains Avatar-related data.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="AvatarData"]/AvatarData/*'/>
    public class AvatarData
    {
        /// <summary>The Avatar System Code that Tingen will use.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/SystemCode/*'/>
        public string SystemCode { get; set; }

        /// <summary>The original <see cref="OptionObject"/> sent from Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/SentOptionObject/*'/>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The original Script Parameter sent from Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/SentScriptParameter/*'/>
        public string SentScriptParameter { get; set; }

        /// <summary>The OptionObject that may be modified by Tingen.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/WorkOptionObject/*'/>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject that will be returned to Avatar.</summary>
        /// <include file='XmlDoc/Common_doc.xml' path='Common/Term[@name="Term"]/ReturnOptionObject/*'/>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new <see cref="AvatarData"/> object.</summary>
        /// <param name="sentOptionObject">The <see cref="SentOptionObject"/> sent from Avatar.</param>
        /// <param name="sentScriptParameter">The <see cref="SentScriptParameter"/> sent from Avatar.</param>
        /// <returns>All of the data/information Tingen needs in order to do work.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Avatar_doc.xml' path='Outpost31/Cs[@name="AvatarData"]/BuildObject/*'/>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new AvatarData
            {
                SystemCode          = "defined-at-runtime",
                SentOptionObject    = sentOptionObject,
                SentScriptParameter = sentScriptParameter.ToLower(),
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }
    }
}