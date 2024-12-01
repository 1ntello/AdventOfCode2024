using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.CrossCuttingConcerns
{
    public static class NumberHelpers
    {
        public static int DifferenceBetweenNumbers(int value1, int value2)
        {
            return Math.Abs(value1 - value2);
        }
    }
}
