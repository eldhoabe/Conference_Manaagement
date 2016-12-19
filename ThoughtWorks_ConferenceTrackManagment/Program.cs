using System;
using System.Linq;
using ThoughtWorks_ConferenceTrackManagment.Models;
using ThoughtWorks_ConferenceTrackManagment.Models.Sheduler;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;
using ThoughtWorks_ConferenceTrackManagment.Utilties;
using ThoughtWorks_ConferenceTrackManagment.UtiltiesImplementation;

namespace ThoughtWorks_ConferenceTrackManagment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string filePath = @"E:\thoughts.txt";

            IFileReader fileReader = new FileReader(new MyFile());
            var lines = fileReader.ReadFile(filePath);

            var sessionCollection = new Parser().ParseToSession(lines.ToList());

            const int morningMaxDuration = 180;
            var morningstartTime = new DateTime(2016, 2, 1, 9, 0, 0);

            const int eveningMaxDuration = 240;
            var eveningstartTime = new DateTime(2016, 2, 1, 1, 0, 0);


            var taskManager = new TaskManager(new Sheduler(), morningstartTime, eveningstartTime, morningMaxDuration,
                eveningMaxDuration);

            var programmesSheduled = taskManager.TaskSheduler(sessionCollection);

            foreach (var program in programmesSheduled)
            {
                Console.WriteLine("{0} {1}", program.StartTime.ToString("HH:mm"), program.Title);
            }


            Console.ReadLine();
        }
    }
}