namespace YamlConfig.Test
{
    [YamlConfig("DifferentFileConfig.yml")]
    public class DifferentFileConfig
    {
        public string Bob { get; set; }
    }
}
