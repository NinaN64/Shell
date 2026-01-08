public class Shell
{
    public void Run()
    {
        List<string> pathVariable =
        Environment.GetEnvironmentVariable("PATH").Split(':').ToList();
        var TypeOfCommands = new HashSet<string> { "type", "exit", "echo", "pwd"};
        var homePath = Environment.GetEnvironmentVariable("HOME");

        while(true)
        {
            Console.Write("$ ");
            string command = Console.ReadLine();
            string firstCommand = command.Split(" ")[0];
            string[] listOfArg = command.Split(" ");

            if(command != null)
            {
                command.RunCommand();
                continue;
            }

            Console.WriteLine(firstCommand + ": command not found");

        }
    }
}
