namespace PersistentAnalysis;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a command.
/// </summary>
/// <param name="name">The command name.</param>
[method: JsonConstructor]
internal class Command(string name)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="initCommand">The init command.</param>
    public Command(InitCommand initCommand)
        : this(nameof(InitCommand))
    {
        InitCommand = initCommand;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="exitCommand">The exit command.</param>
    public Command(ExitCommand exitCommand)
        : this(nameof(ExitCommand))
    {
        ExitCommand = exitCommand;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="updateCommand">The update command.</param>
    public Command(UpdateCommand updateCommand)
        : this(nameof(UpdateCommand))
    {
        UpdateCommand = updateCommand;
    }

    /// <summary>
    /// Gets the command name.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the InitCommand.
    /// </summary>
    public InitCommand? InitCommand { get; init; }

    /// <summary>
    /// Gets the ExitCommand.
    /// </summary>
    public ExitCommand? ExitCommand { get; init; }

    /// <summary>
    /// Gets the UpdateCommand.
    /// </summary>
    public UpdateCommand? UpdateCommand { get; init; }
}
