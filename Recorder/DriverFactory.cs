using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder
{
    public static class DriverFactory
    {
        public static Driver GetDriver(DriverType driverType)
        {
            switch(driverType)
            {
                case DriverType.Chrome: return new ChromeDriver();
                case DriverType.FireFox: return new FireFoxDriver();
                default: return new ChromeDriver();
            }
        }
    }
}
