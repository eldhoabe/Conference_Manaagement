using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;

namespace ThoughtWorks_ConferenceTrackManagment.Models
{
    public class TaskManager
    {
        private readonly ISheduler _sheduler;

        public TaskManager(ISheduler sheduler, DateTime morningDateTime, DateTime eveningDateTime,
            int morningMaxDuration, int eveningMaxDuration)
        {
            _sheduler = sheduler;
            MorningStartTime = morningDateTime;
            EveningStartTime = eveningDateTime;
            MorningDuration = morningMaxDuration;
            EveningDuration = eveningMaxDuration;
        }

        public TaskManager(ISheduler sheduler, MorningSession MorningSession, EveningSession eveningSession)
        {
            _sheduler = sheduler;
            _morningSession = MorningSession;
        }

        public int MorningDuration { get; set; }

        public int EveningDuration { get; set; }

        public DateTime MorningStartTime { get; set; }
        public DateTime EveningStartTime { get; set; }

        private readonly MorningSession _morningSession;

        /// <summary>
        ///     Create the task and shedule the time
        /// </summary>
        /// <param name="programmsToBeSheduled"></param>
        /// <returns></returns>
        public List<Session> TaskSheduler(List<Session> programmsToBeSheduled)
        {


            var morningSession = new MorningSession(MorningStartTime, MorningDuration, _sheduler);
            var sheduledProgramms = morningSession.CreateShedule(programmsToBeSheduled);

            var eveningSessionCandiates = programmsToBeSheduled.Except(sheduledProgramms).ToList();

            var eveningSession = new EveningSession(EveningStartTime, EveningDuration, _sheduler);
            sheduledProgramms.AddRange(eveningSession.CreateShedule(eveningSessionCandiates));


            return sheduledProgramms;
        }

        public List<Session> TaskSheduler1(List<Session> programmes)
        {
            return _morningSession.CreateShedule(programmes);
        }
    }
}