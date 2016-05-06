namespace YamlConfig.Example
{
    [YamlConfig("MyDifferentFileConfig.yml")]
    public class MyDifferentFileConfig
    {
        public string Bob { get; set; }
    }
}
