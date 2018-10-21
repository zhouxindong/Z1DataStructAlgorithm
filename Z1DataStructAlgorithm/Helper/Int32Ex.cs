using System;
using System.Collections.Generic;

namespace Z1DataStructAlgorithm.Helper
{
    public static class Int32Ex
    {
        public static bool InRange(this int value, int bound1, int bound2)
        {
            var up_bound = Math.Max(bound1, bound2);
            var down_bound = Math.Min(bound1, bound2);

            return value >= down_bound && value <= up_bound;
        }
    }
}