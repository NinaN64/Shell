public class CdCommand : DefaultCommand
{
    public string Name => "cd";
    private string? homePath = Environment.GetEnvironmentVariable("HOME");

    public void RunCommand(string arg)
    {
        if(arg[1] == "~")
        {
            Environment.CurrentDirectory = homePath;
        }
        else if(Directory.Exists(arg[1]))
        {
            Environment.CurrentDirectory = (arg[1]);
        }
        else
        {
            Console.WriteLine("cd: " + arg[1] + ": No such file or directory");
        }
    }
}