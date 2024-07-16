namespace SeaHoldemLogic
{
    public interface ISeaLogger
    {
        public void Trace(string message);
        public void Debug(string message);
        public void Info(string message);
        public void Warn(string message);
        public void Error(string message);
        public void Fatal(string message);
    }
}
