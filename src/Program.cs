class Program
{
    static void Main()
    {
        // TODO: Uncomment the code below to pass the first stage
        while(true)
        {
            Console.Write("$ ");
            var TypeOfCommands = new HashSet<string> { "type", "exit", "echo" };
            string command = Console.ReadLine();
            if(command.ToLower() == "exit") break;
            else if(command.StartsWith("type"))
                if(TypeOfCommands.Any(x => TypeOfCommands.Contains(command.Substring(5))))
                    Console.WriteLine(command.Substring(5) + " is a shell builtin");
                else
                    Console.WriteLine(command.Substring(5) + " not found");
            else if(command.StartsWith("echo"))
                Console.WriteLine(command.Substring(5));
            else
                Console.WriteLine(command + ": command not found");
        }
        
    }
}
