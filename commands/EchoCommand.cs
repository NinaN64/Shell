public class EchoCommand : DefaultCommand
{
    public string Name => "echo";

    public void RunCommand(string[] arg)
    {
        var argument = string.Join(" ", arg[1..]);
        argument = argument.Trim('\'', '\"');
        Console.WriteLine(argument);
    }
        
}
