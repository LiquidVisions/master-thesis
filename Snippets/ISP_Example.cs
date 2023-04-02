// Create
public interface ICreateGateway<in TEntity>
    where TEntity : class
{
    bool Create(TEntity entity);
}

// Read
public interface IGetGateway<out TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> GetAll();

    TEntity GetById(object id);
}

// Update
public interface IUpdateGateway<in TEntity>
    where TEntity : class
{
    bool Update(TEntity entity);
}

// Delete
public interface IDeleteGateway<in TEntity>
    where TEntity : class
{
    bool Delete(TEntity entity);

    bool DeleteAll();

    bool DeleteById(object id);
}

internal class AppSeederInteractor : IEntitySeederInteractor<App>
{
    private readonly ICreateGateway<App> createGateway;
    private readonly IDeleteGateway<App> deleteGateway;
    private readonly Parameters parameters;

    public AppSeederInteractor(IDependencyFactoryInteractor dependencyFactory)
    {
        createGateway = dependencyFactory.Get<ICreateGateway<App>>();
        deleteGateway = dependencyFactory.Get<IDeleteGateway<App>>();
        parameters = dependencyFactory.Get<Parameters>();
    }

    public int SeedOrder => 1;

    public int ResetOrder => 1;

    public void Seed(App app)
    {
        app.Id = parameters.AppId;
        app.Name = "PanthaRhei.Generated";
        app.FullName = "LiquidVisions.PanthaRhei.Generated";

        createGateway.Create(app);
    }

    public void Reset() => deleteGateway.DeleteAll();
}