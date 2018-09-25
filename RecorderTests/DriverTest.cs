using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recorder.Tests
{
    [TestClass]
    public class DriverTest
    {
        [TestMethod]
        public void StartDriver()
        {
            var driver = DriverFactory.GetDriver(Browser.Chrome);
            driver.StartDriver();
            Assert.IsTrue(driver.IsConnected());
            driver.CloseDriver();
        }
    }
}
