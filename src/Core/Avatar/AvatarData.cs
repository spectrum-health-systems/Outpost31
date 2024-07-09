// u240709.0000_code
// u240709.0000_documentation

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar-specific data and logic.</summary>
    /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/AvatarData/*'/>
    public class AvatarData
    {
        /// <summary>The System Code that Tingen will use.</summary>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/SystemCode/*'/>
        public string SystemCode { get; set; }

        /// <summary>The Script Parameter sent from Avatar.</summary>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/ScriptParameter/*'/>
        public string SentScriptParameter { get; set; }

        /// <summary>The original OptionObject sent from Avatar.</summary>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/SentOptionObject/*'/>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>TheOptionObject that may be modified during the Tingen session.</summary>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/WorkOptionObject/*'/>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>TheOptionObject that will be returned to Avatar.</summary>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/ReturnOptionObject/*'/>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData object.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <returns>The necessary AvatarNX data.</returns>
        /// <include file='XMLDoc/Outpost31.Core.Avatar_doc.xml' path='Doc/Sec[@name="avatardata"]/BuildObject/*'/>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new AvatarData
            {
                SystemCode          = "defined-at-runtime",
                SentScriptParameter = sentScriptParameter.ToLower(),
                SentOptionObject    = sentOptionObject,
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }
    }
}