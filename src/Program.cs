using System.Diagnostics;
class Program
{
    
    static string checkFullPath (List<string> pathVariable, string argument)
    {
        string firstOrDefault = null;
        foreach (var path in pathVariable)
        {
            string fullPath = path + "/" + argument;
            if (!File.Exists(fullPath))
                continue;

            var mode = File.GetUnixFileMode(fullPath);
            if ((mode & UnixFileMode.UserExecute) != 0)
            {
                firstOrDefault = fullPath;
                break;
            }
        }
        return firstOrDefault;
    }
    static void Main()
    {
        List<string> pathVariable =
        Environment.GetEnvironmentVariable("PATH").Split(':').ToList();
        var TypeOfCommands = new HashSet<string> { "type", "exit", "echo", "pwd"};

        while(true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine();
            string firstCommand = command.Split()[0];
            string[] listOfArg = command.Split();

            if(firstCommand.ToLower() == "exit") break;
            else if(firstCommand == "type")
            {
                var argument = command.Substring(5);
                if(TypeOfCommands.Any(x => TypeOfCommands.Contains(argument)))
                {
                    Console.WriteLine(argument + " is a shell builtin");
                }
                else
                {
                    
                    string firstOrDefault = checkFullPath(pathVariable, argument);
                    if (!string.IsNullOrWhiteSpace(firstOrDefault)) 
                    {
                        Console.WriteLine($"{argument} is {firstOrDefault}");
                    } 
                    else 
                    {
                        Console.WriteLine($"{argument}: not found");
                    }
                }
            }
            else if(firstCommand == "echo")
            {
                Console.WriteLine(command.Substring(5));
            }
            else if(firstCommand == "pwd")
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
            }
            else if(firstCommand == "cd")
            {
                if(Directory.Exists(listOfArg[1]))
                {
                    Environment.CurrentDirectory = (listOfArg[1]);
                }
                else
                {
                    Console.WriteLine("cd: " + listOfArg[1] + ": No such file or directory");
                }
            }
            else
                {
                    string fullPath = checkFullPath(pathVariable, firstCommand);

                    if (fullPath != null)
                    {
                        Process.Start(firstCommand, listOfArg[1..]).WaitForExit();
                    }
                    else
                    {
                        Console.WriteLine(firstCommand + ": command not found");
                    }
                }
        }
        
    }
}
