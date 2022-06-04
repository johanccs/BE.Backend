namespace BE.Contracts
{
    public interface ILoggerService
    {
        void LoginIngo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
