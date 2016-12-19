using System;
using System.Collections.Generic;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sessions
{
    /// <summary>
    ///     The representation of session
    /// </summary>
    public interface ISession
    {
        /// <summary>
        ///     Allocate Session
        /// </summary>
        /// <param name="unOrderedSession"></param>
        /// <returns></returns>
        List<Session> CreateShedule(List<Session> unOrderedSession);

        #region Properties

        DateTime StartTime { get; set; }
        int MaxDuration { get; set; }

        #endregion
    }
}