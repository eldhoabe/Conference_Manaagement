using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sheduler
{
    public class Sheduler : ISheduler
    {
        /// <summary>
        /// Shedule the session
        /// </summary>
        /// <param name="session">The programms</param>
        /// <param name="startTime">The start time</param>
        /// <param name="maxDuration">maximum duration</param>
        /// <returns></returns>
        public List<Session> SheduleSession(List<Session> session, DateTime startTime, int maxDuration)
        {
            #region Boundary Condition

            if (session == null || session.Count < 1)
                throw new ArgumentNullException("session");

            #endregion

            var plannedSession = new List<Session>();

            foreach (var prgm in session.Where(prgm => prgm.Duration + plannedSession.Sum(g => g.Duration) <= maxDuration))
            {
                if (!plannedSession.Any())
                    prgm.StartTime = startTime;
                else
                {
                    prgm.StartTime = prgm.StartTime.AddMinutes(plannedSession.Last().Duration);
                }

                plannedSession.Add(prgm);
            }

            return plannedSession;
        }
    }
}