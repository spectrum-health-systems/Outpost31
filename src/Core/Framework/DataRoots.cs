namespace Outpost31.Core.Framework
{
    public class DataRoots
    {
        /// <summary>The Tingen data root.</summary>
        public string Tingen { get; set; }

        /// <summary>The Avatar System Code root</summary>
        public string SystemCode { get; set; }

        /// <summary>Raw data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Export\</item>
        ///    <item>Import\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string RawData { get; set; }

        /// <summary>Messages are here.</summary>
        /// <remarks>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string Message { get; set; }

        /// <summary>Public data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Public data is available to users that have access to the %TingenDataRoot%\Public directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Export\</item>
        ///    <item>Report\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string Public { get; set; }

        /// <summary>Remote data is located here.</summary>
        /// <remarks>
        ///  <para>
        ///   Remote data is available to users that have access to the %TingenDataRoot%\Remote directory.
        ///  </para>
        ///  <para>
        ///   This directory contains the following subdirectories:
        ///   <list type="bullet">
        ///    <item>Alert\</item>
        ///    <item>Error\</item>
        ///    <item>Export\</item>
        ///    <item>Report\</item>
        ///    <item>Warning\</item>
        ///   </list>
        ///  </para>
        /// </remarks>
        public string Remote { get; set; }

        /// <summary>Session-specific session data is located here.</summary>
        public string Session { get; set; }
    }
}
