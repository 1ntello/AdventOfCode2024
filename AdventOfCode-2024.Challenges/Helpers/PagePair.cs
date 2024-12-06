using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges.Helpers
{
    public class PagePair
    {
        public PagePair(int p1, int p2)
        {
            PageNumber1 = p1;
            PageNumber2 = p2;
        }
        public int PageNumber1 { get; set; } 
        public int PageNumber2 { get; set; }
    }
}
