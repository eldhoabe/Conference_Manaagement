using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thoughts.UnitTest.UnitTestHelpers;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;

namespace Thoughts.UnitTest
{
    [TestClass]
    public class ShedulerUnitTest
    {
        [TestMethod]
        public void Sheduler_Throw_ArgumentException()
        {

            //Act
            var rs = new Sheduler();


            //Assert
            ExceptionAssert.Throws<ArgumentNullException>(() => rs.SheduleSession(null, new DateTime(), 0));
        }


        [TestMethod]
        public void Sheduler_StartTimeIsSheduled()
        {
            //Arrange
            var result = new Sheduler();
            var date = new DateTime(2016, 2, 1, 9, 0, 0);
            var session = new List<Session>
            {
                new Session() {Duration = 30, Title = "A1"},
                new Session() {Duration = 30, Title = "A2"},
                new Session() {Duration = 30, Title = "A3"},
                new Session() {Duration = 30, Title = "A4"},
                new Session() {Duration = 30, Title = "A5"},
                new Session() {Duration = 30, Title = "A6"},
                new Session() {Duration = 30, Title = "A7"},
                new Session() {Duration = 30, Title = "A8"},
            };

            //Act

            var sheduler = result.SheduleSession(session, date, 180);

            //Assert
            Assert.IsTrue(sheduler.FirstOrDefault().StartTime == date);

        }

        [TestMethod]
        public void Sheduler_IsProgramSheduled()
        {
            //Arrange
            var sheduled = new Sheduler();
            var date = new DateTime(2016, 2, 1, 9, 0, 0);
            var session = new List<Session>
            {
                new Session() {Duration = 30, Title = "A1"},
                new Session() {Duration = 30, Title = "A2"},
                new Session() {Duration = 30, Title = "A3"},
                new Session() {Duration = 30, Title = "A4"},
                new Session() {Duration = 30, Title = "A5"},
                new Session() {Duration = 30, Title = "A6"},
                new Session() {Duration = 30, Title = "A7"},
                new Session() {Duration = 30, Title = "A8"},
            };

            //Act

            var result = sheduled.SheduleSession(session, date, 180);

            //Assert
            Assert.IsTrue(result.FirstOrDefault().StartTime == date);


            var secondItem = result.Skip(1).FirstOrDefault();
            var expectedTime = date.AddMinutes(secondItem.Duration);

            Assert.IsTrue(secondItem.StartTime == expectedTime);

        }
    }
}
