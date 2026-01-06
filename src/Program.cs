class Program
{
    static void Main()
    {
        List<string> pathVariable =
        Environment.GetEnvironmentVariable("PATH").Split(':').ToList();
        var TypeOfCommands = new HashSet<string> { "type", "exit", "echo" };

        while(true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine();

            if(command.ToLower() == "exit") break;
            else if(command.StartsWith("type"))
            {
                var argument = command.Substring(5);

                if(TypeOfCommands.Any(x => TypeOfCommands.Contains(argument)))
                {
                    Console.WriteLine(argument + " is a shell builtin");
                }
                else
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

                if (!string.IsNullOrWhiteSpace(firstOrDefault)) {
                    Console.WriteLine($"{argument} is {firstOrDefault}");
                } else {
                    Console.WriteLine($"{argument}: not found");
                }
                }
            }
            else if(command.StartsWith("echo"))
                Console.WriteLine(command.Substring(5));
            else
                Console.WriteLine(command + ": command not found");
        }
        
    }
}
