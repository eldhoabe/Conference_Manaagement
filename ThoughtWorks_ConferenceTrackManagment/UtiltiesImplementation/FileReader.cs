using System;
using System.Collections.Generic;
using System.IO;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;

namespace ThoughtWorks_ConferenceTrackManagment.Utilties
{
    /// <summary>
    ///     The file reader
    ///     Used to read the content in the file.
    /// </summary>
    public class FileReader : IFileReader
    {
        private readonly IFile _file;

        public FileReader(IFile file)
        {
            _file = file;
        }


        /// <summary>
        ///     Read the file using File
        /// </summary>
        /// <param name="fileName">The filePath</param>
        /// <returns>Collection of string</returns>
        public IEnumerable<string> ReadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("The fileName is null or empty");

            if (!_file.Exists(fileName))
                throw new FileNotFoundException(string.Format(
                    "The file is not found {0} .Make sure the file accessable", fileName));

            try
            {
                return _file.ReadLines(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}