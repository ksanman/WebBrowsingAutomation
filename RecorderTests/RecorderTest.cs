using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recorder.Tests
{
    [TestClass]
    public class Recorder
    {
        [TestMethod]
        public void StartDriver()
        {
            var driver = DriverFactory.GetDriver(DriverType.Chrome);
            driver.StartDriver();
            Assert.IsTrue(driver.IsConnected());
            driver.CloseDriver();
        }

        [TestMethod]
        public void WaitForClickEvent()
        {
            //TODO: Create webserver for listening to events that occur on the page. 
        }
    }
}
