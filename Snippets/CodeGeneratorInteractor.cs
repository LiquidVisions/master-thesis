/// <summary>
/// Implements the contract <seealso cref="ICodeGeneratorInteractor"/>.
/// </summary>
internal sealed class CodeGeneratorInteractor : ICodeGeneratorInteractor
{
    // ... other code

    /// <inheritdoc/>
    public void Execute()
    {
        foreach (IExpanderInteractor expander in expanders
            .OrderBy(x => x.Model.Order))
        {
            expander.Harvest();

            Clean();

            expander.PreProcess();
            expander.Expand();
            expander.Rejuvenate();
            expander.PostProcess();
        }
    }
    
    // ... other code
}