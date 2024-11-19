// u240820.1131_code
// u241031_documentation

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>The Tingen session component that contains Avatar-related data.</summary>
    /// <include file='XmlDoc/Outpost31.Core.Avatar.AvatarData_doc.xml' path='Outpost31.Core.Avatar.AvatarData/Type[@name="Class"]/AvatarData/*'/>
    public class AvatarData
    {
        /// <summary>The Avatar System Code that Tingen will interface with.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="AvatarSystemCodes"]/AvatarSystemCode/*'/>
        public string SystemCode { get; set; }

        /// <summary>The original data structure sent from Avatar.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="OptionObjects"]/SentOptionObject/*'/>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The original Script Parameter sent from Avatar.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="OptionObjects"]/SentOptionObject/*'/>
        public string SentScriptParameter { get; set; }

        /// <summary>The data structure that (is potentially) modified during a Tingen Session.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="OptionObjects"]/WorkOptionObject/*'/>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The data structure that is returned to Avatar.</summary>
        /// <include file='XmlDoc/Outpost31-Common_doc.xml' path='Outpost31-Common/Type[@name="OptionObjects"]/ReturnOptionObject/*'/>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData data structure.</summary>
        /// <param name="sentOptionObject">The SentOptionObject data structure sent from Avatar.</param>
        /// <param name="sentScriptParameter">The SentScriptParameter sent from Avatar.</param>
        /// <returns>All of the data/information Tingen needs in order to do work.</returns>
        /// <include file='XmlDoc/Outpost31.Core.Avatar.AvatarData_doc.xml' path='Outpost31.Core.Avatar.AvatarData/Type[@name="Method"]/BuildObject/*'/>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
             * need to create a log file here, use a Primeval Log.
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

/*
=================
DEVELOPMENT NOTES
=================

*/