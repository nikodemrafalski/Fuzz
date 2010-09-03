using System;
using AForge.Fuzzy;

namespace Logic.MembershipFunctions
{
    public class VeryHedge : IMembershipFunction
    {
        private readonly IMembershipFunction membershipFunction;

        public VeryHedge(IMembershipFunction membershipFunction)
        {
            this.membershipFunction = membershipFunction;
        }

        public double GetMembership(double x)
        {
            return Math.Pow(this.membershipFunction.GetMembership(x), 2);
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