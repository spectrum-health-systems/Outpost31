// u240624.0843_code
// u240702.1250_documentation

using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar-specific data and logic.</summary>
    /// <remarks>
    ///     <para>
    ///         <b>About this class</b><br/>
    ///         This class should only contain the following Avatar-specific data:<br/>
    ///         <list type="bullet">
    ///             <item>The <paramref name="AvatarSystemCode"/></item>
    ///             <item>The <paramref name="SentScriptParameter"/></item>
    ///             <item>The <paramref name="SentOptionObject"/></item>
    ///             <item>The <paramref name="WorkOptionObject"/></item>
    ///             <item>The <paramref name="ReturnOptionObject"/></item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         <b>More information</b><br/>
    ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObjects</a><br/>
    ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-paramater">Script Parameter</a><br/>
    ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-codes">System Codes</a>
    ///     </para>
    ///     <para>
    ///         <b>Also...</b><br/>
    ///         Please see the <a href="https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen documentation</a> for more information.
    ///     </para>
    /// </remarks>
    public class AvatarData
    {
        /// <summary>The <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-codes">System Code</a> that Tingen will be using.</summary>
        public string AvatarSystemCode { get; set; }

        /// <summary>The <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-parameter">Script Parameter</a> sent from AvatarNX.</summary>
        public string SentScriptParameter { get; set; }

        /// <summary>The original <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObject</a> sent from AvatarNX.</summary>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObject</a> that may be modified during the Tingen session.</summary>
        public OptionObject2015 WorkOptionObject { get; set; }

        /// <summary>The <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObject</a> that will be returned to AvatarNX.</summary>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /// <summary>Builds a new AvatarData object.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from AvatarNX.</param>
        /// <param name="sentScriptParameter">The ScriptParameter sent from AvatarNX.</param>
        /// <remarks>
        ///     <para>
        ///         <b>About this method</b><br/>
        ///         - The <paramref name="sentScriptParameter"/> is converted to lowercase so it is easier to compare against.<br/>
        ///         - The <paramref name="workOptionObject"/> is cloned from the  <paramref name="sentOptionObject"/> so it can be modified without affecting the original data.<br/>
        ///         - The <paramref name="returnOptionObject"/> is initally set to "null", and will be formatted/finalized prior to returning to AvatarNX.
        ///     </para>
        ///     <para>
        ///         <b>More information</b><br/>
        ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-optionobject">OptionObjects</a><br/>
        ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-script-paramater">Script Parameter</a><br/>
        ///         <a href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Glossary.md#avatar-system-codes">System Codes</a>
        ///     </para>
        /// </remarks>
        /// <returns>The necessary AvatarNX data.</returns>
        public static AvatarData BuildObject(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace logs cannot be used here. For debugging purposes, use a Primeval log. */

            return new AvatarData
            {
                AvatarSystemCode    = "defined-at-runtime",
                SentScriptParameter = sentScriptParameter.ToLower(),
                SentOptionObject    = sentOptionObject,
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }
    }
}