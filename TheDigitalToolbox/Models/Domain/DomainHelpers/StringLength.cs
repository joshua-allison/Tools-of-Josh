using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDigitalToolbox.Models
{
    public class StringLength
    {
        // I created this test to make writing validation tests easier
        public StringLength(int MinLength, int MaxLength)
        {
            Min = MinLength;
            Max = MaxLength;
        }
        public int Min { get; set; }
        public int GetMin() { return Min; }
        public int Max { get; set; }
        public int GetMax() { return Max; }
    }
}
