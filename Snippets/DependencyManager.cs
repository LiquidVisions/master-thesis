/// <summary>
/// The <see cref="IServiceCollection">dependency container</see>.
/// </summary>
internal class DependencyManagerInteractor : IDependencyFactoryInteractor, IDependencyManagerInteractor
{
    private readonly IServiceCollection serviceCollection;
    private IServiceProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="DependencyManagerInteractor"/> class.
    /// </summary>
    /// <param name="serviceCollection">The <see cref="IServiceCollection"/>.</param>
    public DependencyManagerInteractor(IServiceCollection serviceCollection)
    {
        this.serviceCollection = serviceCollection;
    }

    /// <inheritdoc/>
    public void AddTransient(Type serviceType, Type implementationType)
    {
        serviceCollection.AddTransient(serviceType, implementationType);
    }

    /// <inheritdoc/>
    public IDependencyFactoryInteractor Build()
    {
        provider = serviceCollection.BuildServiceProvider();

        return this;
    }

    /// <inheritdoc/>
    public IEnumerable<T> GetAll<T>()
    {
        if (provider == null)
        {
            Build();
        }

        return provider.GetServices<T>();
    }

    /// <inheritdoc/>
    public T Get<T>()
    {
        if (provider == null)
        {
            Build();
        }

        return provider.GetRequiredService<T>();
    }

    /// <inheritdoc/>
    public void AddSingleton<T>(T singletonObject)
        where T : class => serviceCollection.AddSingleton(singletonObject);

    /// <inheritdoc/>
    public void AddSingleton(Type serviceType, Type implementationType)
    {
        serviceCollection.AddSingleton(serviceType, implementationType);
    }
}