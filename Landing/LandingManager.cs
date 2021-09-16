using System;
using System.Collections.Generic;
using System.Linq;

namespace Landing
{
    public class LandingManager
    {
        private readonly int AcceptableFromX = 5;
        private readonly int AcceptableToX = 15;
        private readonly int AcceptableFromY = 5;
        private readonly int AcceptableToY = 15;
        private readonly int SizeOfX = 100;
        private readonly int SizeOfY = 100;
        private List<LandingArea> CurrentLandings;

        public LandingManager(int acceptableFromX, int acceptableToX, int acceptableFromY, int acceptableToY, int sizeOfX, int sizeOfY)
        {
            AcceptableFromX = acceptableFromX;
            AcceptableToX = acceptableToX;
            AcceptableFromY = acceptableFromY;
            AcceptableToY = acceptableToY;
            SizeOfX = sizeOfX;
            SizeOfY = sizeOfY;

            CurrentLandings = new List<LandingArea>();
        }

        public string MakeALanding(int x, int y)
        {
            var response = LandControl(x, y);
            return response switch
            {
                LandingPositionResponse.CorrectPosition => "ok for landing",
                LandingPositionResponse.IncorrectPosition or LandingPositionResponse.PreviousRocket => "clash",
                LandingPositionResponse.OutOfPlatform => "out of platform",
                _ => throw new ArgumentOutOfRangeException("Argument not listed"),
            };
        }

        private LandingPositionResponse LandControl(int x, int y)
        {
            if (x < 0 || x > SizeOfX)
                throw new LandingException($"X Should be greater than 0 and lower than {SizeOfX}");
            if (y < 0 || y > SizeOfY)
                throw new LandingException($"Y Should be greater than 0 and lower than {SizeOfY}");

            if ((x >= AcceptableFromX && x <= AcceptableToX) && (y >= AcceptableFromY && y <= AcceptableToY))
            {
                var response = LookAvailable(x, y);
                if (response == LandingPositionResponse.CorrectPosition)
                {
                    CurrentLandings.Add(new LandingArea { X = x, Y = y });
                }
                return response;
            }
            else
            {
                return LandingPositionResponse.OutOfPlatform;
            }
        }

        private LandingPositionResponse LookAvailable(int x, int y)
        {
            if (CurrentLandings.Any(s => s.X == x && s.Y == y))
                return LandingPositionResponse.PreviousRocket;
            else if (CurrentLandings.Any(item => !(x < item.X - 1 || x > item.X + 1) || !(y < item.Y - 1 || y > item.Y + 1)))
                return LandingPositionResponse.IncorrectPosition;
            else
                return LandingPositionResponse.CorrectPosition;
        }
    }
}
