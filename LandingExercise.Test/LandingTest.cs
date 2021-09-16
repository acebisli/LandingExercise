using System;
using Xunit;

namespace LandingExercise.Test
{
    public class LandingTest
    {
        [Fact]
        public void MakeALanding_Normal_Position()
        {
            Landing.LandingManager manager = new Landing.LandingManager(5, 15, 5, 15,100,100);
            var response = manager.MakeALanding(6, 7);
            Assert.True(response == "ok for landing");
            response = manager.MakeALanding(8, 10);
            Assert.True(response == "ok for landing");
            response = manager.MakeALanding(7, 7);
            Assert.True(response == "clash");
            response = manager.MakeALanding(15, 15);
            Assert.True(response == "ok for landing");
            response = manager.MakeALanding(25, 25);
            Assert.True(response == "out of platform");
        }

        [Fact]
        public void MakeALanding_GreaterSize_Position()
        {
            Landing.LandingManager manager = new Landing.LandingManager(5, 15, 5, 15, 100, 100);
            Assert.Throws<Landing.LandingException>(() => manager.MakeALanding(17, 105));
        }

        [Fact]
        public void MakeALanding_LowerSize_Position()
        {
            Landing.LandingManager manager = new Landing.LandingManager(5, 15, 5, 15, 100, 100);
            Assert.Throws<Landing.LandingException>(() => manager.MakeALanding(-5, 105));
        }

        [Fact]
        public void MakeALanding_ChangeSize_LookIsEverythingOk()
        {
            Landing.LandingManager manager = new Landing.LandingManager(35, 75, 35, 75, 1000, 1000);
            var response = manager.MakeALanding(38, 40);
            Assert.True(response == "ok for landing");
            response = manager.MakeALanding(88, 100);
            Assert.True(response == "out of platform");
        }

    }
}
