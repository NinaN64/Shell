using System.Diagnostics;

public class Shell
{
    private readonly CommandDictionary commandDictionary;
    private readonly PathFinder pathFinder;

    public Shell(CommandDictionary commandDictionary, PathFinder pathFinder)
    {
        this.commandDictionary = commandDictionary;
        this.pathFinder = pathFinder;
    }

    public void Run()
    {
        while(true)
        {
            Console.Write("$ ");
            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input)) continue;

            string commandName = input.Split(" ")[0];
            string listOfArg = input.Substring(commandName.Length);

            if(commandDictionary.isCommandABuiltIn(commandName))
            {
                var command = commandDictionary.Get(commandName);
                if(command != null)
                {
                    command.RunCommand(listOfArg);
                }
                continue;
            }

            string? fullPath = pathFinder.checkFullPath(commandName);

            if (fullPath != null)
            {
                Process.Start(commandName, listOfArg).WaitForExit();
            }
            else
            {
                Console.WriteLine(commandName + ": command not found");
            }
        }
    }
}
