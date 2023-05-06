internal class Logger : ILogger
{
    /// <summary>
    /// Writes the message at the trace level.
    /// </summary>
    /// <param name="message">The message that needs to be logged.</param>
    public void Trace(string message)
    {
        Trace(message, null);
    }

    /// <summary>
    /// Writes the diagnostic message at the Trace level using the specified expandRequestModel.
    /// </summary>
    /// <param name="message">A string containing format items.</param>
    /// <param name="args">Arguments to format.</param>
    public void Trace(string message, params object[] args)
    {
        internalLogger.Trace(message, args);
    }
}