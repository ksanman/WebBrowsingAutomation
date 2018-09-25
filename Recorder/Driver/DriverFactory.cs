namespace Recorder
{
    public static class DriverFactory
    {
        public static Driver GetDriver(Browser driverType, bool shouldUseProxy = false)
        {
            switch(driverType)
            {
                case Browser.Chrome: return new ChromeDriver(shouldUseProxy);
                case Browser.FireFox: return new FireFoxDriver(shouldUseProxy);
                default: return new ChromeDriver(shouldUseProxy);
            }
        }
    }
}
