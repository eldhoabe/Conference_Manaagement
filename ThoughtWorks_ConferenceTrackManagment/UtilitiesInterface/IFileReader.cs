using System.Collections.Generic;

namespace ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface
{
    /// <summary>
    ///     The file reader
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        ///     Read the file using File
        /// </summary>
        /// <param name="fileName">The filePath</param>
        /// <returns>Collection of string</returns>
        IEnumerable<string> ReadFile(string fileName);
    }
}