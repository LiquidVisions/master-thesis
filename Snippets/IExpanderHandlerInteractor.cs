/// <summary>
/// Specifies the interface of an expander handler.
/// </summary>
/// <typeparam name="TExpander"><seealso cref="IExpanderInteractor"/></typeparam>
public interface IExpanderHandlerInteractor<out TExpander> : IExecutionInteractor
    where TExpander : class, IExpanderInteractor
{
    /// <summary>
    /// Gets the name of the <see cref="IExpanderHandlerInteractor{TExpander}"/>.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the order in whitch the handler should be executed.
    /// </summary>
    int Order { get; }

    /// <summary>
    /// Gets the Expander that is of type <typeparamref name="TExpander"/>.
    /// </summary>
    TExpander Expander { get; }
}