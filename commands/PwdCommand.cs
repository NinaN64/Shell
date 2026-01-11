public class PwdCommand : DefaultCommand
{
    public string Name => "pwd";

    public void RunCommand(string arg)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
    }
}