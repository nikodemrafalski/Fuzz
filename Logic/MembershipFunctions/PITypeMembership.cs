using System;
using AForge.Fuzzy;

namespace Logic.MembershipFunctions
{
    public class PITypeMembership : IMembershipFunction
    {
        private readonly double center;

        private readonly STypeMembership sTypeMembershipLeft;
        private readonly STypeMembership sTypeMembershipRight;

        public PITypeMembership(double left, double center, double right)
        {
            this.center = center;

            this.sTypeMembershipLeft = new STypeMembership(left, center);
            this.sTypeMembershipRight = new STypeMembership(center, right);

        }

        public double GetMembership(double x)
        {
            double result;
            if (x <= center)
            {
                result = this.sTypeMembershipLeft.GetMembership(x);
            }
            else
            {
                result = 1 - this.sTypeMembershipRight.GetMembership(x);
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