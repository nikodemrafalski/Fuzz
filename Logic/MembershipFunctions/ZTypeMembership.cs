using AForge.Fuzzy;

namespace Logic.MembershipFunctions
{
    public class ZTypeMembership : IMembershipFunction
    {
        private STypeMembership sTypeMembership;
        public ZTypeMembership(double a, double c)
        {
            this.sTypeMembership = new STypeMembership(a, c);
        }

        public double GetMembership(double x)
        {
            return 1 - sTypeMembership.GetMembership(x);
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