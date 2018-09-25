using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace Recorder
{
    public class ChromeDriver : Driver
    {
        public ChromeDriver(bool shouldUseProxy = false)
            : base(shouldUseProxy)
        {

        }

        protected override void StartInstance()
        {
            ChromeOptions options = GetChromeOptions();

            var driver = new OpenQA.Selenium.Chrome.ChromeDriver(@"..\..\..\chromedriver\", options);
            m_driver = new EventFiringWebDriver(driver);
            m_driver.Manage().Window.Maximize();
        }

        private ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();

            if (shouldUseProxy)
            {
                options.Proxy = new Proxy()
                {
                    IsAutoDetect = false,
                    HttpProxy = "127.0.0.1:12434",
                    SslProxy = "127.0.0.1:12434",
                };
            };

            options.AddArgument("ignore-certificate-errors");
            return options;
        }
    }
}
