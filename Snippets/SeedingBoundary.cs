internal class SeedingBoundary : ISeedingBoundary
{
    private readonly List<ISeederInteractor<App>> seeders;

    public SeedingBoundary(IDependencyFactoryInteractor dependencyFactory)
    {
        seeders = dependencyFactory
            .GetAll<ISeederInteractor<App>>()
            .ToList();
    }

    public void Execute()
    {
        App app = new();

        foreach (var seeder in seeders.OrderBy(x => x.ResetOrder))
        {
            seeder.Reset();
        }

        foreach (var seeder in seeders.OrderBy(x => x.SeedOrder))
        {
            seeder.Seed(app);
        }
    }
}