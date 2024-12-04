using AdventOfCode.CrossCuttingConcerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public class Challenge2 : IChallenge
    {
        public string ChallengePart1(string[] input)
        {
            var listOfReports = StringHelpers.StringArrayToIntListArray(input);
            int safeReports = 0;
            foreach (var report in listOfReports)
            {
                if (IsReportSafe(report))
                {
                    safeReports++;
                    StringHelpers.PrintColoredLine(string.Join(" ", report), ConsoleColor.Green);
                }
                else {
                    StringHelpers.PrintColoredLine(string.Join(" ", report), ConsoleColor.Red);
                }
            }
            return safeReports.ToString();
        }

        public string ChallengePart2(string[] input)
        {
            var listOfReports = StringHelpers.StringArrayToIntListArray(input);
            int safeReports = 0;
            foreach (var report in listOfReports)
            {
                if (IsReportSafe(report))
                {
                    safeReports++;
                    StringHelpers.PrintColoredLine(string.Join(" ", report), ConsoleColor.Green);
                }
                else
                {
                    StringHelpers.PrintColoredLine(string.Join(" ", report), ConsoleColor.Red);

                    // Run simulations for all
                    for (int i = 0; i < report.Count; i++)
                    {
                        var alternativeReport = new List<int>();
                        alternativeReport.AddRange(report);
                        alternativeReport.RemoveAt(i);

                        if (IsReportSafe(alternativeReport))
                        {
                            StringHelpers.PrintColoredLine(string.Join(" ", alternativeReport), ConsoleColor.Green);
                            safeReports++;
                            break;
                        }
                    }
                }
            }
            return safeReports.ToString();
        }

        private bool IsReportSafe(List<int> report)
        {
            // run a while loop, and keep going while safe. 
            bool safe = true;
            bool increasingMode = report[0] < report[1];

            // we start at x + 1
            int counter = 1;
            int currentValue = report[1];
            int pastValue = report[0];

            while (safe && counter != report.Count)
            {
                currentValue = report[counter];

                if (!IsComparisonSafe(currentValue, pastValue, increasingMode))
                    safe = false;
                pastValue = currentValue;
                counter++;
            }
            return safe;
        }


        private bool IsComparisonSafe(int p1, int p2, bool increasingMode)
        {
            bool safe = true;
            int numberDifference = NumberHelpers.DifferenceBetweenNumbers(p1, p2);

            if (numberDifference < 1 || numberDifference > 3)
                safe = false;
            else if (increasingMode && p1 < p2)
                safe = false;
            else if (!increasingMode && p1 > p2)
                safe = false;
            return safe;

        }
    }
}
