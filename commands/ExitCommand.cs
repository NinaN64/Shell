public class ExitCommand : DefaultCommand
{
    public string Name => "exit";

    public void RunCommand(string arg)
    {
        Environment.Exit(0);
    }
}