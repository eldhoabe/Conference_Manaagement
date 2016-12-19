using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sessions
{
    public class EveningSession : ISession
    {
        private readonly ISheduler _sheduler;

        public EveningSession(DateTime startTime, int maxDurartion, ISheduler sheduler)
        {
            StartTime = startTime;
            MaxDuration = maxDurartion;

            _sheduler = sheduler;
        }

        public DateTime StartTime { get; set; }

        public int MaxDuration { get; set; }

        public List<Session> CreateShedule(List<Session> unOrderedSession)
        {
            if (unOrderedSession == null || unOrderedSession.Count < 1)
                throw new ArgumentNullException("unOrderedSession");

            var eveningShedules = _sheduler.SheduleSession(unOrderedSession, StartTime, MaxDuration);

            //Add the networking event between 4 and 5
            if (eveningShedules.LastOrDefault() != null
                && eveningShedules.Last().StartTime.AddMinutes(eveningShedules.Last().Duration).Hour >= 4 
                && (eveningShedules.Last().StartTime.AddMinutes(eveningShedules.Last().Duration)).Hour <= 5)
                eveningShedules.Add(new Session
                {
                    Title = "Networking event",
                    Duration = 60,
                    StartTime = eveningShedules.Last().StartTime.
                        AddMinutes(eveningShedules.Last().Duration)
                });

            return eveningShedules;
        }
    }
}