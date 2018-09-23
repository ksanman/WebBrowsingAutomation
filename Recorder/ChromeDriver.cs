using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace Recorder
{
    public class ChromeDriver : Driver
    {
        protected override void StartInstance()
        {
            var driver = new OpenQA.Selenium.Chrome.ChromeDriver(@"..\..\..\chromedriver\");
            m_driver = new EventFiringWebDriver(driver);
            m_driver.Manage().Window.Maximize();
        }
    }
}
