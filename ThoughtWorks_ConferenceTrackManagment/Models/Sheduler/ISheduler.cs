using System;
using System.Collections.Generic;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sheduler
{
    public interface ISheduler
    {
        /// <summary>
        ///     Shedule the session based on the start timing
        /// </summary>
        /// <param name="session">The session collection</param>
        /// <param name="startTime">The start timing</param>
        /// <param name="maxDuration">Maximum duration</param>
        /// <returns></returns>
        List<Session> SheduleSession(List<Session> session, DateTime startTime, int maxDuration);
    }
}