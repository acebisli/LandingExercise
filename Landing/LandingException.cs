using System;

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
