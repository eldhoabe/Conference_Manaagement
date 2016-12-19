using System;
using System.Collections.Generic;
using System.IO;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;

namespace ThoughtWorks_ConferenceTrackManagment.UtiltiesImplementation
{
    public class MyFile : IFile
    {
        /// <summary>
        ///     Read all line from the file
        /// </summary>
        /// <param name="fileName">The file path</param>
        /// <returns>The collection of lines</returns>
        public IEnumerable<string> ReadLines(string fileName)
        {
            try
            {
                return File.ReadLines(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Check the file exist or not
        /// </summary>
        /// <param name="fileName">The filePath</param>
        /// <returns>File exist <c>True</c></returns>
        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}