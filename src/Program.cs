using System.Diagnostics;
class Program
{
    
    
    static void Main()
    {
        CommandDictionary commandDictionary = new CommandDictionary();
        var ListOfCommands = new DefaultCommand[]
        {
            new CdCommand(),
            new EchoCommand(),
            new ExitCommand(),
            new PwdCommand(),
            new TypeCommand()
        };

        foreach(var com in ListOfCommands)
        {
            commandDictionary.MakeDictionary(com);
        }

        Shell shell = new Shell();
        shell.Run();
    }
}
 