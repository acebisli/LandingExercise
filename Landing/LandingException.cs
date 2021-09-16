using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing
{
    public class LandingException : Exception
    {
        public LandingException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
