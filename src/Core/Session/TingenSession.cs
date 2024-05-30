// u240530.1120

using System;
using Outpost31.Core.Avatar;
using Outpost31.Core.Configuration;
using Outpost31.Core.Framework;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Session
{
    /// <summary>Contains Tingen session logic.</summary>
    /// <remarks>
    ///  <para>  
    ///   Properties for the Tingen session are located in <b>TingenSession.Properties.cs.</b>
    ///  </para> 
    /// </remarks>
    public partial class TingenSession
    {

        /// <summary>Loads the object.</summary>
        /// <param name="configFilePath">The path to the Tingen configuration file.</param>
        /// <param name="sentOptionObject">The OptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from Avatar.</param>
        /// <remarks>
        ///  <para>
        ///   AbSession contains all of the information that Tingen needs to do what it does, including data from:
        ///   <list type="bullet">
        ///    <item>The Tingen configuration file, which contains data that does not change between sessions</item>
        ///    <item>Static data that is specific to the current session, such as framework components</item>
        ///    <item>Runtime settings that are specific to the current session, such as the session timestamp</item>
        ///    <item>The <paramref name="sentOptionObject"/> and <paramref name="sentScriptParameter"/></item>
        ///    <item>Abatab Modules</item>
        ///   </list>
        ///  </para>
        ///  <para>
        ///     All strings in this method have been converted to lowercase to make it easlier to compare going forward.
        ///  </para>
        /// </remarks>
        /// <returns>An AbSession object.</returns>
        public static TingenSession Load(string configFilePath, OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            //Outpost31.Core.Debuggler.Primeval.Log($"[Outpost31.Core.Session.TingenSession.Load()]"); /* <- For development use only */

            var tnConfig = TingenConfiguration.Load(configFilePath);

            return new TingenSession
            {
                TingenMode       = tnConfig.TingenMode.ToLower(),
                TingenVersion    = tnConfig.TingenVersionBuild.Split('-')[0],
                TingenBuild      = tnConfig.TingenVersionBuild.Split('-')[1],
                AvatarSystemCode = tnConfig.AvatarSystemCode.ToLower(),
                SessionTimestamp = DateTime.Now.ToString("yyyyMMdd-HHmmssfffffff"),
                LogMode          = tnConfig.LogMode,
                LogDelay         = tnConfig.LogDelay,
                TnFramework      = TingenFramework.BuildComponents(tnConfig.TingenDataRoot, tnConfig.AvatarSystemCode),
                AvComponents     = AvatarComponents.Setup(sentScriptParameter, sentOptionObject)
            };
        }
    }
}