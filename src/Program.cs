using System.Diagnostics;
class Program
{   
    static void Main()
    {
        CommandDictionary commandDictionary = new CommandDictionary();
        PathFinder pathFinder = new PathFinder();
        var ListOfCommands = new DefaultCommand[]
        {
            new CdCommand(),
            new EchoCommand(),
            new ExitCommand(),
            new PwdCommand(),
            new TypeCommand(commandDictionary)
        };

        foreach(var com in ListOfCommands)
        {
            commandDictionary.MakeDictionary(com);
        }

        var shell = new Shell(commandDictionary, pathFinder);
        shell.Run();
    }
}
 