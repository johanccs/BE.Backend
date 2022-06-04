namespace BE.Domain.Helpers
{
    public class Settings
    {
        public string Url { get; private set; }

        public string Api_Key { get; private set; }

        public Settings(string url, string api_key)
        {
            Url = url;
            Api_Key = api_key;
        }
    }
}
