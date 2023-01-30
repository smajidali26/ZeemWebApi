namespace Zeem.Core.Infrastructure
{
    public class ZeemConfig
    {
        public string ConnectionString { get; set; }

        public string SecretKeyForToken { get; set; }

        public string ValidAudience { get; set; }

        public string ValidIssuer { get; set; }
    }
}
