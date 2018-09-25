using OpenQA.Selenium.Support.Events;
using System;

namespace Recorder
{
    public abstract class Driver : IDriver, IDisposable
    {

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

        protected bool shouldUseProxy;
        protected EventFiringWebDriver m_driver;

        protected abstract void StartInstance();

        public Driver(bool shouldUseProxy = false)
        {
            this.shouldUseProxy = shouldUseProxy;
        }

        public void StartDriver()
        {
            StartInstance();
            InjectEventCaptureScript();
            m_driver.Navigate().GoToUrl(@"https://www.google.com");
            m_driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMinutes(2);
            WebDriver = m_driver;
        }

        public void CloseDriver()
        {
            m_driver.Dispose();
            WebDriver = null;
        }

        private void InjectEventCaptureScript()
        {
            var script = @"(function() {
                            var events = [];
                            window.addEventListener('click', function (e) { events.push([Date.now(), 'click',  [e.clientX, e.clientY]]); }, true);
                            window.addEventListener('keyup', function (e) { events.push([Date.now(), 'keyup', String.fromCharCode(e.keyCode)]); }, true);
                            window._getUserEvents = function() { return events; };
                            })();";
            m_driver.ExecuteScript(script);
        }

        public bool IsConnected()
        {
            return (m_driver != null || m_driver.WindowHandles.Count == 1);
        }

        public void Dispose()
        {
            ((IDisposable)m_driver).Dispose();
        }
    }
}
