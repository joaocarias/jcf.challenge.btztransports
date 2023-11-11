namespace Jcf.Challenge.Server.Extensions.Helpers
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetConfiguration(string config)
        {
            try
            {
                return _configuration[config];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
