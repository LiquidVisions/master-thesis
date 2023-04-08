public class ExpandDatabaseContextHandlerInteractor 
    : IExpanderHandlerInteractor<CleanArchitectureExpander>
{
    // ... other code
    public bool CanExecute => 
        parameters
            .GenerationMode
            .HasFlag(GenerationModes.Default) || 
        parameters
            .GenerationMode
            .HasFlag(GenerationModes.Extend);
    // ... other code
}
