// u240531.0804

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar-specific data. (see DataFromAvatar.Properties.cs for more information about this class).</summary>
    public partial class DataFromAvatar
    {
        /// <summary>Builds an object that contains all of the Avatar-specific data Tingen needs.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   This will be added to the <paramref name="TingenSession"/> object, and will be available whenever we need it.
        ///  </para>
        /// </remarks>
        /// <returns>The necessary Avatar data.</returns>
        public static DataFromAvatar Build(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            //Outpost31.Core.Debuggler.PrimevalLog.Create($"[Outpost31.Core.Avatar.DataFromAvatar.Build()]"); /* <- For development use only */

            /* DEPRECIATED 240531 (see below)
             */
            //var parameterComponent = GetParameterComponents(sentScriptParameter);

            return new DataFromAvatar
            {
                SentScriptParameter = sentScriptParameter,
                SentOptionObject    = sentOptionObject,
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }

        /* DEPRECIATED 240531
         * Going forward, we will just be using the SentScriptParameter to determin what work needs to be done. This is
         * a holdover from the old way of doing things, and will be removed in the future.
         */
        ///// <summary>Get the individual components of the ScriptParameter.</summary>
        ///// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        ///// <remarks>
        /////  <para>
        /////   The ScriptParameter is a "-" delimited string that is passed from Avatar and contains all of the information that Tingen
        /////   needs to know to do the required work.
        /////  </para>
        /////  <para>
        /////   The ScriptParamater is broken down into four components:
        /////    <list type="table">
        /////     <item>
        /////      <term>Module</term>
        /////      <description>The Tingen <i>Module</i> that will be doing the session work (ex: "Admin").</description>
        /////     </item>
        /////      <item>
        /////      <term>Command</term>
        /////     <description>The requested <i>Command</i> (ex: "Service"). </description>
        /////     </item>
        /////     <item>
        /////      <term>Action</term>
        /////      <description>The requested <i>Action</i> (ex: "Status").</description>
        /////     </item>
        /////     <item>
        /////      <term>Option</term>
        /////      <description>The optional <i>Option</i> (ex: "Update").</description>
        /////     </item>
        /////    </list>
        /////   </para>
        /////  <para>
        /////   The ScriptParameter should have the <i>Module</i>, <i>Command</i>, and <i>Action</i> components, but in some cases it
        /////   will also have the <i>Option</i> component.<br/><br/>
        /////   And there may be future cases where only the <i>Module</i> and <i>Command</i> components are present.<br/><br/>
        /////   We don't want to assume! So we'll set the components to "undefined" if they are not present, and we will only parse the
        /////   components that are present.
        /////  </para>
        ///// </remarks>
        ///// <returns>The individual components of the ScriptParameter.</returns>
        //private static Dictionary<string, string> GetParameterComponents(string sentScriptParameter)
        //{
        //    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Avatar.DataFromAvatar.GetParameterComponents()]"); /* <- For development use only */

        //    var parameterComponent = SetParameterComponentsToUndefined();
        //    var numberOfComponents = sentScriptParameter.Split('-').Length;

        //    for (int component = 0; component < numberOfComponents; component++)
        //    {
        //        switch (component)
        //        {
        //            case 0:
        //                parameterComponent["Module"] = sentScriptParameter.Split('-')[0].ToLower();
        //                break;

        //            case 1:
        //                parameterComponent["Command"] = sentScriptParameter.Split('-')[1].ToLower();
        //                break;

        //            case 2:
        //                parameterComponent["Action"] = sentScriptParameter.Split('-')[2].ToLower();
        //                break;

        //            case 3:
        //                parameterComponent["Option"] = sentScriptParameter.Split('-')[3].ToLower();
        //                break;

        //            default:
        //                // TODO: Exit gracefully.
        //                break;
        //        }
        //    }

        //    return parameterComponent;
        //}

        ///// <summary>Set all of the ScriptParameter components to "undefined".</summary>
        ///// <remarks>
        /////  <para>
        /////   Since we don't want to assume that all of the components are present, we'll set them all to "undefined" if they are not.
        /////  </para>
        ///// </remarks>
        ///// <returns>The individual ScriptParameter components, all set to "undefined".</returns>
        //private static Dictionary<string, string> SetParameterComponentsToUndefined()
        //{
        //    //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Avatar.DataFromAvatar.SetParameterComponentsToUndefined()]"); /* <- For development use only */

        //    return new Dictionary<string, string>
        //    {
        //        {"Module",  "undefined" },
        //        {"Command", "undefined" },
        //        {"Action",  "undefined" },
        //        {"Option",  "undefined" }
        //    };
        //}
    }
}