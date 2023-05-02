internal class ExpanderPluginLoaderInteractor : IExpanderPluginLoaderInteractor
{
    \\...other code

    /// <inheritdoc/>
    public void LoadAllRegisteredPluginsAndBootstrap(App app)
    {
        foreach (Expander expander in app.Expanders)
        {
            string rootDirectory = Path.Combine(expandRequestModel.ExpandersFolder, expander.Name);
            string[] files = directoryService.GetFiles(rootDirectory, searchPattern, SearchOption.TopDirectoryOnly);
            if (!files.Any())
            {
                throw new InitializationException($"No plugin assembly detected in '{rootDirectory}'. The plugin assembly should match the following '{searchPattern}' pattern");
            }

            LoadPlugins(files)
                .ForEach(assembly => BootstrapPlugin(expander, assembly));

        }
    }
    
    \\...other code

    private List<Assembly> LoadPlugins(string[] assemblyFiles)
    {
        List<Assembly> plugins = new();

        foreach (string assemblyFile in assemblyFiles)
        {
            try
            {
                Assembly assembly = LoadPlugin(assemblyFile);
                plugins.Add(assembly);
            }
            catch (Exception innerException)
            {
                throw new InitializationException($"Failed to load plugin '{assemblyFile}'.", innerException);
            }
        }

        return plugins;
    }

    private Assembly LoadPlugin(string assemblyFile)
    {
        Assembly assembly = assemblyContext.Load(assemblyFile);
        logger.Trace($"Plugin context {assemblyFile} has been successfully loaded...");
        return assembly;
    }

    private void BootstrapPlugin(Expander expander, Assembly assembly)
    {
        Type bootstrapperType = assembly.GetExportedTypes()
            .Where(x => x.IsClass && !x.IsAbstract)
            .Single(x => x.GetInterfaces()
            .Contains(typeof(IExpanderDependencyManagerInteractor)));

        IExpanderDependencyManagerInteractor expanderDependencyManager = (IExpanderDependencyManagerInteractor)activator
            .CreateInstance(bootstrapperType, expander, dependencyManager);

        expanderDependencyManager.Register();
    }
}
