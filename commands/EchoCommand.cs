public class EchoCommand : DefaultCommand
{
    public string Name => "echo";

    public void RunCommand(string[] arg)
    {
        foreach(string arguments in arg)
        {
            Console.Write(arguments);
        }
        
    }
}