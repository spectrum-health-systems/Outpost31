// u240531.1229

using System.Reflection;
using ScriptLinkStandard.Objects;

namespace Outpost31.Core.Avatar
{
    /// <summary>Avatar-specific data. (see DataFromAvatar.Properties.cs for more information about this class).</summary>
    public partial class DataFromAvatar
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///   <para>
        ///    The executing assembly is defined at the start of the class so it can be easily used throughout the class when creating
        ///    log files.
        ///   </para>
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

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
            /* Can't put a trace log here, so we'll use a Primeval log for debugging.
             */
            //LogEvent.Primeval(AssemblyName);

            return new DataFromAvatar
            {
                SentScriptParameter = sentScriptParameter.ToLower(),
                SentOptionObject    = sentOptionObject,
                WorkOptionObject    = sentOptionObject.Clone(),
                ReturnOptionObject  = null
            };
        }
    }
}