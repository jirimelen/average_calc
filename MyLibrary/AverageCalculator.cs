using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class AverageCalculator
    {
        public double calculate(int totalMarksValue, int totalMarksImpact)
        {
            if(totalMarksImpact != 0 && totalMarksValue != 0)
            {
                return (double) totalMarksValue / totalMarksImpact;
            }
            return 0;
        }
    }
}
