using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceConsumer.Model
{
    public class TwoThirdAverageGame
    {
        private static int SUM = 0;
        private static int COUNT = 0;

        public static void Submit(int submission)
        {
            SUM += submission;
            COUNT++;
        }

        public static double GetTwoThirdOfAverage()
        {
            return SUM * 2.0 / 3.0 / COUNT;
        }

        public static int GetNumberOfSubmissions()
        {
            return COUNT;
        }
    }
}
