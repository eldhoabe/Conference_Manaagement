using System.Collections.Generic;

namespace ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface
{
    /// <summary>
    ///     The file Interface
    /// </summary>
    public interface IFile
    {
        /// <summary>
        ///     Read all line from the file
        /// </summary>
        /// <param name="fileName">The file path</param>
        /// <returns>The collection of lines</returns>
        IEnumerable<string> ReadLines(string fileName);

        /// <summary>
        ///     Check the file exist or not
        /// </summary>
        /// <param name="fileName">The filePath</param>
        /// <returns>File exist <c>True</c></returns>
        bool Exists(string fileName);
    }
}