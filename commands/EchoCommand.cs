public class EchoCommand : DefaultCommand
{
    public string Name => "echo";

    public void RunCommand(string[] arg)
    {
        foreach(string arguments in arg[1..])
        {
            Console.WriteLine(arguments);
        }
        
    }
}