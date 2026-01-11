public class CdCommand : DefaultCommand
{
    public string Name => "cd";
    private string? homePath = Environment.GetEnvironmentVariable("HOME");

    public void RunCommand(string arg)
    {
        if(arg == "~")
        {
            Environment.CurrentDirectory = homePath;
        }
        else if(Directory.Exists(arg))
        {
            Environment.CurrentDirectory = (arg);
        }
        else
        {
            Console.WriteLine("cd: " + arg + ": No such file or directory");
        }
    }
}