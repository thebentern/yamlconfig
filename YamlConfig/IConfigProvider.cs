namespace YamlConfig.Core
{
    /// <summary>
    /// Interface for providing config instances 
    /// </summary>
    /// <typeparam name="T">Target config type</typeparam>
    public interface IConfigProvider<T>
    {
        /// <summary>
        /// Gets the resolved config type.
        /// </summary>
        /// <value>
        /// The resolve.
        /// </value>
        T Resolve { get; }
    }
}
