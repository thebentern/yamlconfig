using YamlConfig.Core;

namespace YamlConfig.Console.Example
{

    [YamlConfig("MyDifferentFileConfig.yml")]
    public class MyDifferentFileConfig
    {
        public string Bob { get; set; }
    }
}
