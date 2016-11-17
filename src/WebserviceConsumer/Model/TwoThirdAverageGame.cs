using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceConsumer.Model
{
    public class TwoThirdAverageGame
    {
        private static Dictionary<string, double> playersAndTheirNumbers = new Dictionary<string, double>();

        public static void Submit(string name, double submission)
        {
            playersAndTheirNumbers[name] = submission;
        }

        public static double GetTwoThirdOfAverage()
        {
            if (playersAndTheirNumbers == null || playersAndTheirNumbers.Count == 0)
                return 0;

            return playersAndTheirNumbers.Values.Average() * 2.0 / 3.0;
        }

        public static string GetWinner()
        {
            double currentSmallestDelta = double.MaxValue;
            string currentLeader = "No one";
            double answer = GetTwoThirdOfAverage();

            foreach (string name in playersAndTheirNumbers.Keys)
            {
                double delta = Math.Abs(playersAndTheirNumbers[name] - answer);
                if (delta < currentSmallestDelta)
                {
                    currentSmallestDelta = delta;
                    currentLeader = name;
                }
            }
            return currentLeader;
        }

        public static int GetNumberOfSubmissions()
        {
            return playersAndTheirNumbers.Count();
        }

        public static void Reset()
        {
            playersAndTheirNumbers = new Dictionary<string, double>();
        }
    }
}
