// u240607.1004

using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Provides Avatar-specific data and logic.</summary>
    /// <remarks>
    ///  <para>
    ///   This class should only contain Avatar-specific data:<br/>
    ///   <list type="bullet">
    ///    <item>The <paramref name="AvatarSystemCode"/></item>
    ///    <item>The <paramref name="SentOptionObject"/> sent from Avatar</item>
    ///    <item>The <paramref name="SentScriptParameter"/> sent from Avatar</item>
    ///    <item>The <paramref name="WorkOptionObject"/> and <paramref name="ReturnOptionObject"/>, which are derived from the <paramref name="SentOptionObject"/></item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   - The <paramref name="AvatarSystemCode"/> is initially set in Tingen.asmx.cs (or Tingen_development.asmx.cs).<br/>
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
        ///   - The original <see cref="SentScriptParameter"/> sent from Avatar.<br/>
        ///  </para>
        ///  <para>
        ///   The ScriptParameter is a "-" delimited string with the following compoents:
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
        ///   - This should <i>not be modified</i>.<br/>
        ///   - All session work should use the <paramref name="WorkOptionObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that is modified during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   - When a session is initialized, the <paramref name="WorkOptionObject"/> is cloned from the <paramref name="SentOptionObject"/>.<br/>
        ///   - All session work should use the <paramref name="WorkOptionObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The OptionObject2015 that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - Prior to returning data to Avatar, the <paramref name="ReturnOptionObject"/> is cloned from the <paramref name="WorkOptionObject"/>.<br/>
        ///   - The <paramref name="ReturnOptionObject"/> is property formatted, and is the only valid OptionObject that will be accepted by Avatar.
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData object.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <param name="avSystemCode">The Avatar System Code.</param>
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