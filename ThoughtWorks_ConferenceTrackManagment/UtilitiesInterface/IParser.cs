using System.Collections.Generic;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;

namespace ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface
{
    /// <summary>
    ///     The Parser used to parse the content to session
    /// </summary>
    public interface IParser
    {
        List<Session> ParseToSession(List<string> collection);
    }
}