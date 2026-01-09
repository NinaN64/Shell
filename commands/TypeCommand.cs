
public class TypeCommand : DefaultCommand
{
    public string Name => "type";
    private readonly CommandDictionary commandDictionary;

    public TypeCommand(CommandDictionary commandDictionary)
    {
        this.commandDictionary = commandDictionary;
    }

    public void RunCommand(string[] arg)
    {
        if(commandDictionary.isCommandABuiltIn(arg[1]))
        {
            Console.WriteLine(arg[1] + " is a shell builtin");
        }
        else
        {
            PathFinder pathFinder = new PathFinder();
            string firstOrDefault = pathFinder.checkFullPath(arg[0]);
            if (!string.IsNullOrWhiteSpace(firstOrDefault)) 
            {
                Console.WriteLine($"{arg[0]} is {firstOrDefault}");
            } 
            else 
            {
                Console.WriteLine($"{arg[0]}: not found");
            }
        }
    }
}