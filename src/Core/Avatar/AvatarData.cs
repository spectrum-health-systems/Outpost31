// u240605.0954

using System.Reflection;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar data.</summary>
    /// <remarks>
    ///  <para>
    ///   This class should only contain Avatar-specific data:<br/>
    ///   <list type="bullet">
    ///    <item>The Avatar System Code</item>
    ///    <item>The <paramref name="OptionObject"/> sent from Avatar</item>
    ///    <item>The <paramref name="ScriptParameter"/> sent from Avatar</item>
    ///    <item>The<paramref name="WorkObject"/> and <paramref name="ReturnObject"/>, which are derived from the SentOptionObject</item>
    ///   </list>
    ///  </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///   - The Avatar System Code is initially set in Tingen.asmx.cs (or Tingen_development.asmx.cs).<br/>
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
        public string SystemCode { get; set; }

        /// <summary>The original ScriptParameter sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The original <see cref="ScriptParameter"/> sent from Avatar.<br/>
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
        public string ScriptParameter { get; set; }

        /// <summary>The original OptionObject sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - This should <i>not be modified</i>.<br/>
        ///   - All session work should use the <paramref name="WorkObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentObject { get; set; }

        /// <summary>The OptionObject that is modified during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   - When a session is initialized, the <paramref name="WorkObject"/> is cloned from the <paramref name="SentObject"/>.<br/>
        ///   - All session work should use the <paramref name="WorkObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkObject { get; set; }

        /// <summary>The OptionObject2015 that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - Prior to returning data to Avatar, the <paramref name="ReturnObject"/> is cloned from the <paramref name="WorkObject"/>.<br/>
        ///   - The <paramref name="WorkObject"/> is property formatted, and is the only valid OptionObject that will be accepted by Avatar.
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnObject { get; set; }

        /// <summary>Assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Define the assembly name here so it can be used to write log files throughout the class.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds a new AvatarData object.</summary>
        /// <param name="sentObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <param name="avatarSystemCode">The Avatar System Code.</param>
        /// <returns>The necessary Avatar data.</returns>
        public static AvatarData BuildNew(OptionObject2015 sentObject, string sentScriptParameter, string avatarSystemCode)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new AvatarData
            {
                SystemCode      = avatarSystemCode,
                ScriptParameter = sentScriptParameter.ToLower(),
                SentObject      = sentObject,
                WorkObject      = sentObject.Clone(),
                ReturnObject    = null
            };
        }
    }
}

/*

Development notes
-----------------

*/