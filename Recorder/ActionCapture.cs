using Server;
using System;

namespace Recorder
{
    public class ActionCapture : IDisposable
    {
        public bool IsRecording { get; set; }
        private Driver driver;
        public ActionCapture(Browser browser)
        {
            // Start the proxy server
            var proxy = new ProxyServer();

            // Connect the driver, use a proxy for capturing. 
            driver = DriverFactory.GetDriver(browser, true);

            //Do stuff
            driver.StartDriver();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
