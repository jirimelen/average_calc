using System;
using System.Collections.Generic;
using System.Text;

using MyLibrary.types;

namespace MyLibrary
{
    public class AverageCalculator
    {
        public double calculate(List<Mark> marks)
        {
            double totalValue = 0;
            double totalImpact = 0;
            foreach (var mark in marks)
            {
                totalValue += mark.Impact * mark.Value;
                totalImpact += mark.Impact;
            }

            if(totalImpact != 0 && totalValue != 0)
            {
                double average = (double) totalValue / totalImpact;
                return Math.Round(average, 2);
            }
            return 0.00;
        }
    }
}
