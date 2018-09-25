using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recorder.Tests
{
    [TestClass()]
    public class ActionCaptureTests
    {
        [TestMethod()]
        public void ActionCaptureTest()
        {
            var actionCapture = new ActionCapture(Browser.Chrome);
            Assert.IsFalse(actionCapture is null);
        }
    }
}