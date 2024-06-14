// u240614.1102

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Provides Avatar-specific data and logic.</summary>
    /// <remarks>
    ///  <para>
    ///   This class should only contain Avatar-specific data:<br/>
    ///   <list type="bullet">
    ///    <item>The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-code">AvatarSystemCode</see></item>
    ///    <item>The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-parameter">SentScriptParameter</see></item>
    ///    <item>The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">SentOptionObject</see></item>
    ///    <item>The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">WorkOptionObject</see></item>
    ///    <item>The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">ReturnOptionObject</see></item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-code">AvatarSystemCode</see> is initially set in Tingen.asmx.cs (or Tingen_development.asmx.cs).<br/>
        ///  </para>
        ///  <para>
        ///   Valid Avatar System Codes:
        ///   <list type="table">
        ///    <item>
        ///     <term>UAT</term>
        ///     <description>The System Code used for the development version of Tingen.</description>
        ///    </item>
        ///    <item>
        ///     <term>LIVE</term>
        ///     <description>The System Code used for the production version of Tingen.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string AvatarSystemCode { get; set; }

        /// <summary>The original ScriptParameter sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-parameter">SentScriptParameter</see> is a "-" delimited string with the following compoents:
        ///   <list type="table">
        ///    <item>
        ///     <term>Module</term>
        ///     <description>The Tingen <i>Module</i> that will be doing the session work (ex: "Admin").</description>
        ///    </item>
        ///    <item>
        ///     <term>Command</term>
        ///     <description>The Tingen <i>Command</i> request (ex: "Service").</description>
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
        ///    <c>Admin-Service-Status-Update</c>
        ///   </example>
        ///  </para>
        /// </remarks>
        public string SentScriptParameter { get; set; }

        /// <summary>The original OptionObject sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">SentOptionObject</see><i> should not be modified</i>.<br/>
        ///   - All work should be done with the <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">WorkOptionObject</see>
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that is modified during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   - All work should be done with the <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">WorkOptionObject</see>.<br/>
        ///   - When a Tingen session is initialized, the <paramref name="WorkOptionObject"/> is cloned from the <paramref name="SentOptionObject"/><br/>
        ///   - The <paramref name="WorkOptionObject"/> <i>is not</i> formatted properly for returning to Avatar.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject2015 that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">ReturnOptionObject</see> is formatted properly to be returned to Avatar.<br/>
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData object.</summary>
        /// <param name="sentOptionObject">The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> sent from Avatar.</param>
        /// <param name="sentScriptParameter">The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-parameter">ScriptParameter</see> sent from Avatar.</param>
        /// <param name="avSystemCode">The <see href="github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-option-object">OptionObject</see> to be returned to Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   - The <paramref name="sentScriptParameter"/> is converted to lowercase so it is easier to compare against.<br/>
        ///   - The <paramref name="workOptionObject"/> is initally set to "null", and will be finalized prior to returning to Avatar.<br/>
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

-----------------
Development notes
-----------------


*/