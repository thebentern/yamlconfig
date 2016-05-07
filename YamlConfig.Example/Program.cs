using YamlConfig.Core;

namespace YamlConfig.Console.Example
{
    /// <summary>
    /// Example program for yamlconfig
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for program.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var composition = new CompositionRoot();
            var defaultConfig = composition.Config<MyAppConfig>();
            var differentFileConfig = composition.Config<MyDifferentFileConfig>();
            var myAppConfig = defaultConfig;
        }
    }
}
