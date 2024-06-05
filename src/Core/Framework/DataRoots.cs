namespace Outpost31.Core.Framework
{
    public class DataRoots
    {
        /// <summary>Tingen data root details.</summary>
        public string Tingen { get; set; }

        /// <summary>The Avatar System Code root</summary>
        public string SystemCode { get; set; }

        /// <summary>Raw data.</summary>
        /// <remarks>
        ///  <para>
        ///   - Examples of raw data include import/export files.
        ///  </para>
        /// </remarks>
        public string RawData { get; set; }

        /// <summary>Messages are here.</summary>
        /// <remarks>
        ///  <para>
        ///   - Messages are alerts, errors, warnings, etc.
        ///  </para>
        /// </remarks>
        public string Message { get; set; }

        /// <summary>Data available to authorized users.</summary>
        /// <remarks>
        ///  <para>
        ///   - Public data is available to users that have access to the <b>%TingenDataRoot%\Public\</b> directory.<br/>
        ///   - Public data includes reports, alerts, errors, etc.
        ///  </para>
        /// </remarks>
        public string Public { get; set; }

        /// <summary>Data available to administrators and Tingen Commander.</summary>
        /// <remarks>
        ///  <para>
        ///   - Remote data is available to users that have access to the <b>%TingenDataRoot%\Remote\</b> directory.<br/>
        ///   - Remote data is used by Tingen Commander.
        ///   - Remote data includes reports, alerts, errors, etc.
        ///  </para>
        /// </remarks>
        public string Remote { get; set; }
    }
}

/*

Development notes
-----------------

*/