using YamlConfig.Core;

namespace YamlConfig.Console.Example
{
    [YamlConfig]
    public class MyAppConfig
    {
        public string MuhString { get; set; }

        public int MuhFavoriteNumber { get; set; }

        public string[] MuhListOfThings { get; set; }
    }
}
