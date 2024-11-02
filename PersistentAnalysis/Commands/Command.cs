namespace PersistentAnalysis;

/// <summary>
/// Represents a command.
/// </summary>
internal class Command
{
    /// <summary>
    /// Initializes.
    /// </summary>
    private Command()
    {
    }

    /// <summary>
    /// Gets the command name.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the InitCommand.
    /// </summary>
    public InitCommand? InitCommand { get; set; }

    /// <summary>
    /// Gets or sets the ExitCommand.
    /// </summary>
    public ExitCommand? ExitCommand { get; set; }

    /// <summary>
    /// Gets or sets the UpdateCommand.
    /// </summary>
    public UpdateCommand? UpdateCommand { get; set; }

    /// <summary>
    /// Creates a new instance of a <see cref="Command"/> from the provided <see cref="InitCommand"/>.
    /// </summary>
    /// <param name="initCommand">The init command.</param>
    public static Command Create(InitCommand initCommand)
    {
        return new() { Name = nameof(InitCommand), InitCommand = initCommand };
    }

    /// <summary>
    /// Creates a new instance of a <see cref="Command"/> from the provided <see cref="ExitCommand"/>.
    /// </summary>
    /// <param name="exitCommand">The exit command.</param>
    public static Command Create(ExitCommand exitCommand)
    {
        return new() { Name = nameof(ExitCommand), ExitCommand = exitCommand };
    }

    /// <summary>
    /// Creates a new instance of a <see cref="Command"/> from the provided <see cref="UpdateCommand"/>.
    /// </summary>
    /// <param name="updateCommand">The update command.</param>
    public static Command Create(UpdateCommand updateCommand)
    {
        return new() { Name = nameof(UpdateCommand), UpdateCommand = updateCommand };
    }
}
