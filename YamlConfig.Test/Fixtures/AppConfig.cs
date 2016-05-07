using YamlConfig.Core;

namespace YamlConfig.Test
{
    [YamlConfig(@"Fixtures\Config.yml")]
    public class AppConfig
    {
        public string MuhString { get; set; }

        public int MuhFavoriteNumber { get; set; }

        public string[] MuhListOfThings { get; set; }

        public MuhComplexType MuhComplexType { get; set; }
    }

    public class MuhComplexType
    {
        public string Derp { get; set; }

        public int Derp2 { get; set; }
    }
}
