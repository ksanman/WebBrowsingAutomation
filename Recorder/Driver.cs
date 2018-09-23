using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Recorder
{
    public abstract class Driver : IDriver
    {
        protected EventFiringWebDriver m_driver;
        public EventFiringWebDriver WebDriver
        {
            get
            {
                return m_driver;
            }
            private set
            {
                if (m_driver != value)
                {
                    m_driver = value;
                }
            }
        }

        protected abstract void StartInstance();

        public void StartDriver()
        {
            StartInstance();
            m_driver.Navigated += new EventHandler<WebDriverNavigationEventArgs>(AttachEventScripts);
            WebDriver = m_driver;
        }

        public void CloseDriver()
        {
            m_driver.Dispose();
            WebDriver = null;
        }

        /// <summary>
        /// Attaches event scripts to the page which send their results to a listening server. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="webDriverNavigationEventArgs"></param>
        private void AttachEventScripts(object sender, WebDriverNavigationEventArgs webDriverNavigationEventArgs)
        {
            ((EventFiringWebDriver)sender).ExecuteScript("document.onclick = function(e) { m_pos = 'x: ' + clientX + ' y: ' + clientY; }");
        }

        public bool IsConnected()
        {
            return (m_driver != null || m_driver.WindowHandles.Count == 1);
        }
    }
}
