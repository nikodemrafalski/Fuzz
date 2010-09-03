using System;
using AForge.Fuzzy;

namespace Logic.MembershipFunctions
{
    public class STypeMembership : IMembershipFunction
    {
        private double a;
        private double b;
        private double c;

        public STypeMembership(double a, double c)
        {
            this.a = a;
            this.c = c;
            this.b = (a + c) / 2;
        }

        public double GetMembership(double x)
        {
            double result = 0;

            if (x <= a)
            {
                result = 0;
            }
            else if (a <= x && x <= b)
            {
                result = 2 * Math.Pow((x - a) / (c - a), 2);
            }
            else if (b <= x && x <= c)
            {
                result = 1 - 2 * Math.Pow((x - c) / (c - a), 2);
            }
            else if (x > c)
            {
                result = 1;
            }

            return result;
        }

        public double LeftLimit
        {
            get { return 0; }
        }

        public double RightLimit
        {
            get { return 1; }
        }
    }
}