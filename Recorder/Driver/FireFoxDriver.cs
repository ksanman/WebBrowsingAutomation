namespace Recorder
{
    public class FireFoxDriver : Driver
    {
        public FireFoxDriver(bool shouldUseProxy = false)
            : base(shouldUseProxy)
        {

        }
        protected override void StartInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}