public class ExpandEntitiesHandlerInteractor : IExpanderHandlerInteractor<CleanArchitectureExpander>
{
    // ... other code 

    /// <inheritdoc/>
    public void Execute()
    {
        directory.Create(entitiesFolder);

        foreach (var entity in app.Entities)
        {
            string fullSavePath = Path.Combine(entitiesFolder, $"{entity.Name}.cs");
            templateService.RenderAndSave(pathToTemplate, new { entity }, fullSavePath);
        }
    }
}