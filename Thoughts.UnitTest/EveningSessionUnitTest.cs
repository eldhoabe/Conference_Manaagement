using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thoughts.UnitTest.UnitTestHelpers;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler.Fakes;
using System.Linq;

namespace Thoughts.UnitTest
{
    [TestClass]
    public class EveningSessionUnitTest
    {


        [TestMethod]
        public void EveningSession_Null_ThrowException()
        {
            //Arrange
            DateTime DateTime = new DateTime(2016, 2, 1, 1, 0, 0);


            ISheduler sheduler = new StubISheduler
            {
                SheduleSessionListOfSessionDateTimeInt32 = (list, dateTime, duration) => new List<Session>()
            };


            //Act and Assert
            ExceptionAssert.Throws<ArgumentNullException>(
                () => new EveningSession(DateTime, 240, sheduler).CreateShedule(null));
        }


        [TestMethod]
        public void EveningSession_NetWorkingEvent_IsNotAdded_TimeIsInvalid()
        {
            //Arrange
            var dateTime = new DateTime(2016, 2, 1, 1, 0, 0);

            var mockObject = Enumerable.Repeat(new Session() { Duration = 30, Title = "Test" }, 25);


            ISheduler sheduler = new StubISheduler
            {
                SheduleSessionListOfSessionDateTimeInt32 = (list, dtime, duration) => new List<Session>()
                {
                    new Session()
                    {
                        Title = "Test",
                        Duration = 40,
                        StartTime = new DateTime(2016,2,1,6,0,0)
                    }
                }
            };


            //Act 
            var result =
                 new EveningSession(dateTime, 240, sheduler).CreateShedule(mockObject.ToList());

            //Assert
            Assert.IsFalse(result.Any(h => h.Title.Contains("Networking")), "Expected sequence should not contain netwroking");

        }

        [TestMethod]
        public void EveningSession_NetWorkingEvent_IsNotAdded_TimeIsBefore()
        {
            //Arrange
            var dateTime = new DateTime(2016, 2, 1, 1, 0, 0);

            var mockObject = Enumerable.Repeat(new Session() { Duration = 30, Title = "Test" }, 25);


            ISheduler sheduler = new StubISheduler
            {
                SheduleSessionListOfSessionDateTimeInt32 = (list, dtime, duration) => new List<Session>()
                {
                    new Session()
                    {
                        Title = "Test",
                        Duration = 40,
                        StartTime = new DateTime(2016,2,1,3,0,0)
                    }
                }
            };


            //Act 
            var result =
                 new EveningSession(dateTime, 240, sheduler).CreateShedule(mockObject.ToList());

            //Assert
            Assert.IsFalse(result.Any(h => h.Title.Contains("Networking")), "Expected sequence should not contain netwroking");

        }


        [TestMethod]
        public void EveningSession_NetWorkingEvent_IsAddedToTimeLine()
        {
            //Arrange
            var dateTime = new DateTime(2016, 2, 1, 1, 0, 0);

            var mockObject = Enumerable.Repeat(new Session() { Duration = 30, Title = "Test" }, 25);


            ISheduler sheduler = new StubISheduler
            {
                SheduleSessionListOfSessionDateTimeInt32 = (list, dtime, duration) => new List<Session>()
                {
                    new Session()
                    {
                        Title = "Test",
                        Duration = 40,
                        StartTime = new DateTime(2016,2,1,4,30,0)
                    }
                }
            };


            //Act 
            var result =
                 new EveningSession(dateTime, 240, sheduler).CreateShedule(mockObject.ToList());

            //Assert
            Assert.IsTrue(result.Any(h => h.Title.Contains("Networking")), "Expected sequence should not contain netwroking");

        }

        [TestMethod]
        public void EveningSession_NetWorkingEvent_IsAdded_ValidTiming()
        {
            //Arrange
            var dateTime = new DateTime(2016, 2, 1, 1, 0, 0);

            var mockObject = Enumerable.Repeat(new Session() { Duration = 30, Title = "Test" }, 25);


            ISheduler sheduler = new StubISheduler
            {
                SheduleSessionListOfSessionDateTimeInt32 = (list, dtime, duration) => new List<Session>()
                {
                    new Session()
                    {
                        Title = "Test",
                        Duration = 30,
                        StartTime = new DateTime(2016,2,1,4,30,0)
                    }
                }
            };


            //Act 
            var result =
                 new EveningSession(dateTime, 240, sheduler).CreateShedule(mockObject.ToList());

            var networkingItem = result.FirstOrDefault(h => h.Title.Contains("Networking"));

            //Assert
            Assert.IsNotNull(networkingItem, "Instance is null");
            Assert.IsTrue(networkingItem.StartTime.Hour <= 4 || networkingItem.StartTime.Hour >= 5, "The networking started at invalid time");
            

        }
    }
}
