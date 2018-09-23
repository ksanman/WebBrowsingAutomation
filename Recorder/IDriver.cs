using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;

namespace Recorder
{
    public interface IDriver
    {
        void StartDriver();
        bool IsConnected();
    }
}
