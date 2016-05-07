using SimpleInjector;

namespace YamlConfig.Core
{
    /// <summary>
    /// Bootstrapper for the host application
    /// </summary>
    public class CompositionRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositionRoot"/> class.
        /// </summary>
        public CompositionRoot()
        {
            Container = new Container();
            Container.Register(typeof(IConfigProvider<>), typeof(ConfigProvider<>), Lifestyle.Singleton);
            Container.Verify();
        }

        /// <summary>
        /// Gets or sets the simple injection container
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        protected Container Container { get; set; }

        /// <summary>
        /// Configurations this instance.
        /// </summary>
        /// <typeparam name="T">Configuration type</typeparam>
        /// <returns>Instance of the configuration type</returns>
        public T Config<T>()
        {
            return Container.GetInstance<IConfigProvider<T>>().Resolve;
        }
    }
}
