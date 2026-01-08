
public class TypeCommand : DefaultCommand
{
    public string Name => "type";

    public void RunCommand(string[] arg)
    {
        if(arg[0].isBuilIn) //make a dictionary of commands where this info will be held
        {
            Console.WriteLine(arg[0] + " is a shell builtin");
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