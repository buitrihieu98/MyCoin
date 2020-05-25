using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin
{
    public class Datetime
    {
        public static long GetTime()
        {
            long retval = 0;
            var startTime = new DateTime(1970, 1, 1);
            TimeSpan t = (DateTime.Now.ToUniversalTime() - startTime);
            retval = (Int64)(t.TotalMilliseconds + 0.5);
            return retval;
        }
    }
}