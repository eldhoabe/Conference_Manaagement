using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sessions
{
    public class MorningSession : ISession
    {
        private readonly ISheduler _sheduler;

        public MorningSession(DateTime startTime, int maxDurartion, ISheduler sheduler)
        {
            StartTime = startTime;
            MaxDuration = maxDurartion;

            _sheduler = sheduler;
        }

        public DateTime StartTime { get; set; }

        public int MaxDuration { get; set; }

        public List<Session> CreateShedule(List<Session> unOrderedSession)
        {
            var morningProgramms = _sheduler.SheduleSession(unOrderedSession, StartTime, MaxDuration);

            morningProgramms.Add(new Session
            {
                Title = "Lunch",
                Duration = 60,
                StartTime = morningProgramms.Last().StartTime.
                    AddMinutes(morningProgramms.Last().Duration)
            });


            return morningProgramms;
        }
    }
}