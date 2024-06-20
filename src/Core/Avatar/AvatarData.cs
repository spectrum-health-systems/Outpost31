// u240620.1203

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar-specific data and logic.</summary>
    /// <remarks>
    ///  <para>
    ///   This class should only contain the following Avatar-specific data:<br/>
    ///   <list type="bullet">
    ///    <item>The <paramref name="AvatarSystemCode"/></item>
    ///    <item>The <paramref name="SentScriptParameter"/></item>
    ///    <item>The <paramref name="SentOptionObject"/></item>
    ///    <item>The <paramref name="WorkOptionObject"/></item>
    ///    <item>The <paramref name="ReturnOptionObject"/></item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   - This object is included in the Tingen Session object when Tingen starts.<br/>
    ///  </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The <b>Avatar System Code</b> that Tingen will be using.</summary>
        /// <remarks>
        ///  <para>
        ///   Valid Avatar System Codes:
        ///   <list type="table">
        ///    <item>
        ///     <term>UAT</term>
        ///     <description>Used for the <i>development</i> version of Tingen.</description>
        ///    </item>
        ///    <item>
        ///     <term>LIVE</term>
        ///     <description>Used for the <i>production</i> version of Tingen.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   - More information about Avatar System Codes <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-codes">here</see>.
        ///  </para>
        /// </remarks>
        public string AvatarSystemCode { get; set; }

        /// <summary>The <b>Script Parameter</b> sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   The Script Parameter is a "-" delimited string with the following compoents:
        ///   <list type="table">
        ///    <item>
        ///     <term>Module</term>
        ///     <description>The Tingen <i>Module</i> that will be doing the session work (ex: "Admin").</description>
        ///    </item>
        ///    <item>
        ///     <term>Command</term>
        ///     <description>The Tingen <i>Command</i> request (ex: "All").</description>
        ///    </item>
        ///    <item>
        ///     <term>Action</term>
        ///     <description>The Tingen <i>Action</i> request (ex: "Status").</description>
        ///    </item>
        ///    <item>
        ///     <term>Option</term>
        ///     <description>The optional <i>Action Option</i> (ex: "Update").</description>
        ///    </item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///   <example>
        ///    The following Script Parameter will update all status files:<br/>
        ///    <code>Admin-All-Status-Update</code>
        ///   </example>
        ///  </para>
        /// </remarks>
        public string SentScriptParameter { get; set; }

        /// <summary>The original <b>OptionObject</b> sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - <i>The <paramref name="SentOptionObject"/> should not be modified</i>.<br/>
        ///   - All work should be done with the <paramref name="WorkOptionObject"/>.<br/>
        ///   - More information about OptionObjects <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">here</see>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The <b>OptionObject</b> that may be modified during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   - All work should be done with the <paramref name="WorkOptionObject"/>.<br/>
        ///   - When a Tingen session is initialized, the <paramref name="WorkOptionObject"/> is cloned from the <paramref name="SentOptionObject"/>.<br/>
        ///   - The <paramref name="WorkOptionObject"/> <i>is not</i> formatted properly for returning to Avatar.
        ///   - More information about OptionObjects <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">here</see>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The <b>OptionObject</b> that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The  <paramref name="ReturnOptionObject"/> must be formatted properly to be returned to Avatar.<br/>
        ///   - More information about OptionObjects <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">here</see>.  
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new <b>AvatarData</b> object.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <param name="avSystemCode">The Avatar System Code that Tingen will be working with.</param>
        /// <remarks>
        ///  <para>
        ///   - The <paramref name="sentScriptParameter"/> is converted to lowercase so it is easier to compare against.<br/>
        ///   - The <paramref name="workOptionObject"/> is cloned from the  <paramref name="sentOptionObject"/> so it can be modified without affecting the original data.<br/>
        ///   - The <paramref name="returnOptionObject"/> is initally set to "null", and will be formatted/finalized prior to returning to Avatar.<br/>
        ///   - More information about OptionObjects <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">here</see>.  
        ///  </para>
        /// </remarks>
        /// <returns>The necessary Avatar data.</returns>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter, string avSystemCode)
        {
            return new AvatarData
            {
                AvatarSystemCode    = avSystemCode,
                SentScriptParameter = sentScriptParameter.ToLower(),
                SentOptionObject    = sentOptionObject,
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