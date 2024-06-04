// u240604.1535

using System.Reflection;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar data.</summary>
    /// <remarks>
    ///  <para>
    ///   - Contains the properties for the <see cref="AvatarData"/> class.<br/>
    ///   - Logic for the <see cref="AvatarData"/> class is in the <b>DataFromAvatar.cs</b> file.<br/>
    ///   - Only data sent directly from Avatar, and derived data, should be here.
    ///  </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The Avatar System Code.</summary>
        /// <remarks>
        ///  <para>
        ///  </para>
        /// </remarks>
        public string SystemCode { get; set; }

        /// <summary>The original ScriptParameter sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The original <see cref="ScriptParameter"/> sent from Avatar.<br/>
        ///   - A delimited string that contains necessary information that tells Tingen what it needs to do.<br/>
        ///  </para>
        /// </remarks>
        public string ScriptParameter { get; set; }

        /// <summary>The OptionObject sent from Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - The original <see cref="OptionObject2015"/> sent from Avatar.<br/>
        ///   - Should not be modified, since work is done using the <paramref name="WorkOptionObject"/>.
        ///  </para>
        /// </remarks>
        public OptionObject2015 SentObject { get; set; }

        /// <summary>The OptionObject that will be used to do the work during the session.</summary>
        /// <remarks>
        ///  <para>
        ///   - A clone of the <paramref name="SentOptionObject"/>, used to do the session work.
        ///  </para>
        /// </remarks>
        public OptionObject2015 WorkObject { get; set; }

        /// <summary>The OptionObject2015 that will be returned to Avatar.</summary>
        /// <remarks>
        ///  <para>
        ///   - A clone of the <paramref name="WorkOptionObject"/>, formatted to be returned to Avatar.<br/><br/>
        ///  </para>
        /// </remarks>
        public OptionObject2015 ReturnObject { get; set; }

        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    - Executing assembly is defined here so it can be used when creating log files.
        ///   </para>
        /// </remarks>
        public static string Asm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Builds an object that contains all of the Avatar-specific data Tingen needs.</summary>
        /// <param name="sentObject">The OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   - Data from Avatar, and derived data.<br/>
        ///   - Will be added to the TingenSession so it is available throughout the session.
        ///  </para>
        /// </remarks>
        /// <returns>The necessary Avatar data.</returns>
        public static AvatarData BuildNew(OptionObject2015 sentObject, string scriptParameter, string systemCode)
        {
            /* <!-- For debugging: LogEvent.Primeval(asm); --> */ // To be removed.

            return new AvatarData
            {
                SystemCode      = systemCode,
                ScriptParameter = scriptParameter.ToLower(),
                SentObject      = sentObject,
                WorkObject      = sentObject.Clone(),
                ReturnObject    = null
            };
        }
    }
}

/*

Development notes

- Remove the Primeval calls, potentially replace with Tracelogs.
- If logs aren't written, remove the Asm property.

*/