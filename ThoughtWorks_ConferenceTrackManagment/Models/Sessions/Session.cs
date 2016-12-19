using System;
using System.Diagnostics;

namespace ThoughtWorks_ConferenceTrackManagment.Models.Sessions
{
    /// <summary>
    ///     The represent each session
    /// </summary>
    [DebuggerDisplay("Duration={Duration},ScheduleTime={StartTime}")]
    public class Session

    {
        #region Public properties

        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }

        #endregion
    }
}