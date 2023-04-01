/// <summary>
/// Specifice an interface for an object that needs to be able to execute commands.
/// </summary>
public interface IExecutionInteractor
{
    /// <summary>
    /// Gets a value indicating whether the handler should be executed.
    /// </summary>
    bool CanExecute { get; }

    /// <summary>
    /// Executes the handler.
    /// </summary>
    void Execute();
}