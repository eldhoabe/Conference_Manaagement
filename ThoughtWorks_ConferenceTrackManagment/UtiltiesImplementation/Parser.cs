using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;

namespace ThoughtWorks_ConferenceTrackManagment.UtiltiesImplementation
{
    public class Parser : IParser
    {
        /// <summary>
        ///     The process to parse string to the session
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public List<Session> ParseToSession(List<string> collection)
        {
            #region Boundary

            if (collection == null || !collection.Any())
                throw new ArgumentNullException("collection");

            #endregion

            return collection.Select(line => new Session
            {
                Duration = ParseTime(line.Split(' ').Last()),
                Title = line
            }).ToList();
        }


        /// <summary>
        /// Parse time to integer
        /// </summary>
        /// <param name="theWord"></param>
        /// <exception cref="FormatException"></exception>
        /// <returns></returns>
        internal int ParseTime(string theWord)
        {
            if (string.IsNullOrEmpty(theWord))
                throw new ArgumentNullException("theWord");

            const string minSuffix = "min";
            const string lightiningSuffix = "lightning";

            if (theWord.EndsWith(minSuffix, StringComparison.OrdinalIgnoreCase))
            {
                var time =
                    Convert.ToInt32(theWord.Substring(0, theWord.IndexOf(minSuffix, StringComparison.OrdinalIgnoreCase)));

                return time;
            }
            if (theWord.EndsWith(lightiningSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return 5;
            }


            throw new FormatException("The string format is not met, either " + minSuffix + " or " + lightiningSuffix +
                                      " is supported");
        }
    }
}