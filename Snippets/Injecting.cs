public abstract class AbstractExpander<TExpander> : IExpanderInteractor
    where TExpander : class, IExpanderInteractor
{
    private readonly ILogger logger;
    private readonly IDependencyFactoryInteractor dependencyFactory;
    private readonly App model;

    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractExpander{TExpander}"/> class.
    /// </summary>
    /// <param name="dependencyFactory"><seealso cref="IDependencyFactoryInteractor"/></param>
    protected AbstractExpander(IDependencyFactoryInteractor dependencyFactory)
    {
        this.dependencyFactory = dependencyFactory;

        logger = this.dependencyFactory.Get<ILogger>();
        model = dependencyFactory.Get<App>()
            .Expanders
            .Single(x => x.Name == Name);
    }
}