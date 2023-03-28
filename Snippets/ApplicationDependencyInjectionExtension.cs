public static class DependencyInjectionExtension
{
    ...

    private static IServiceCollection AddSeedersInteractors(this IServiceCollection services)
    {
        services.AddTransient<IEntitySeederInteractor<App>, AppSeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, ExpanderSeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, EntitySeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, FieldSeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, ComponentSeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, ConnectionStringsSeederInteractor>()
            .AddTransient<IEntitySeederInteractor<App>, RelationshipSeederInteractor>();

        return services;
    }
}