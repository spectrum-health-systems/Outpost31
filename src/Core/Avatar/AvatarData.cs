// u240530.0620

using System.Collections.Generic;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Logic for Avatar-specific data (see AvatarData.Properties.cs for more information about this class).</summary>
    public partial class AvatarData
    {
        /// <summary>Builds the Avatar data</summary>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <param name="sentOptionObject">The Option Object sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   All of the necessary OptionObject data is stored here, so it's available when we need it:
        ///    <list type="table">
        ///    <item>
        ///     <term>sentOptionObject</term>
        ///     <description>The original OptionObject sent from Avatar.</description>
        ///    </item>
        ///    <item>
        ///     <term>workOptionObject</term>
        ///     <description>Most of the work is done with this OptionObject.</description>
        ///    </item>
        ///    <item>
        ///     <term>returnOptionObject</term>
        ///     <description>The final OptionObject that is returned to Avatar.</description>
        ///    </item>
        ///   </list>
        ///  </para>
        /// </remarks>
        /// <returns>The necessary Avatar data.</returns>
        public static AvatarData Setup(string sentScriptParameter, OptionObject2015 sentOptionObject)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Avatar.AvatarData.Setup()]"); /* <- For development use only */

            var scriptParameterComponent = GetScriptParameterComponents(sentScriptParameter);

            return new AvatarData
            {
                SentScriptParameter = sentScriptParameter,
                ScriptModule        = scriptParameterComponent["Module"],
                ScriptCommand       = scriptParameterComponent["Command"],
                ScriptAction        = scriptParameterComponent["Action"],
                ScriptOption        = scriptParameterComponent["Option"],
                SentOptionObject    = sentOptionObject,
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }

        /// <summary>Get the individual components of the ScriptParameter.</summary>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   The ScriptParameter is a "-" delimited string that is passed from Avatar and contains all of the information that Tingen
        ///   needs to know to do the required work.
        ///  </para>
        ///  <para>
        ///   The ScriptParamater is broken down into four components:
        ///    <list type="table">
        ///     <item>
        ///      <term>Module</term>
        ///      <description>The Tingen <i>Module</i> that will be doing the session work (ex: "Admin").</description>
        ///     </item>
        ///      <item>
        ///      <term>Command</term>
        ///     <description>The requested <i>Command</i> (ex: "Service"). </description>
        ///     </item>
        ///     <item>
        ///      <term>Action</term>
        ///      <description>The requested <i>Action</i> (ex: "Status").</description>
        ///     </item>
        ///     <item>
        ///      <term>Option</term>
        ///      <description>The optional <i>Option</i> (ex: "Update").</description>
        ///     </item>
        ///    </list>
        ///   </para>
        ///  <para>
        ///   The ScriptParameter should have the <i>Module</i>, <i>Command</i>, and <i>Action</i> components, but in some cases it
        ///   will also have the <i>Option</i> component.<br/>
        ///   And there may be future cases where only the <i>Module</i> and <i>Command</i> components are present.<br/>
        ///   We don't want to assume! So we'll set the components to "undefined" if they are not present, and we will only parse the
        ///   components that are present.
        ///  </para>
        /// </remarks>
        /// <returns>The individual components of the ScriptParameter.</returns>
        private static Dictionary<string, string> GetScriptParameterComponents(string sentScriptParameter)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Avatar.AvatarData.GetScriptParameterComponents()]"); /* <- For development use only */

            var scriptParameterComponent = SetComponentsToUndefined();
            var numberOfComponents       = sentScriptParameter.Split('-').Length;

            for (int component = 0; component < numberOfComponents; component++)
            {
                switch (component)
                {
                    case 0:
                        scriptParameterComponent["Module"] = sentScriptParameter.Split('-')[component].ToLower();
                        break;

                    case 1:
                        scriptParameterComponent["Command"] = sentScriptParameter.Split('-')[1].ToLower();
                        break;

                    case 2:
                        scriptParameterComponent["Action"] = sentScriptParameter.Split('-')[2].ToLower();
                        break;

                    case 3:
                        scriptParameterComponent["Option"] = sentScriptParameter.Split('-')[3].ToLower();
                        break;

                    default:
                        break;
                }
            }

            return scriptParameterComponent;
        }

        /// <summary>Set all of the ScriptParameter components to "undefined".</summary>
        /// <remarks>
        ///  <para>This is done to avoid any issues where values are set to "null", or whatever.</para>>
        /// </remarks>
        /// <returns>The individual ScriptParameter components, all set to "undefined".</returns>
        private static Dictionary<string, string> SetComponentsToUndefined()
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Avatar.AvatarData.SetComponentsToUndefined()]"); /* <- For development use only */

            return new Dictionary<string, string>
            {
                {"Module",  "undefined" },
                {"Command", "undefined" },
                {"Action",  "undefined" },
                {"Option",  "undefined" }
            };
        }
    }
}