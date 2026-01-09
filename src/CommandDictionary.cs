public class CommandDictionary
{
    private Dictionary<string, DefaultCommand> builtInCommands = new ();
    private string? homePath = Environment.GetEnvironmentVariable("HOME");

    public void MakeDictionary(DefaultCommand command)
    {
        builtInCommands[command.Name] = command;
    }

    public bool isCommandABuiltIn(string name)
    {
        return builtInCommands.ContainsKey(name);
    }
    
    public DefaultCommand? Get(string name)
    {
        builtInCommands.TryGetValue(name, out DefaultCommand? cmd);
        return cmd;
    }
}