using System.Diagnostics;
class Program
{
    
    
    static void Main()
    {
        
        
        var TypeOfCommands = new HashSet<string> { "type", "exit", "echo", "pwd"};
        

        while(true)
        {

            else if(firstCommand == "pwd")
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
            }
            else if(firstCommand == "cd")
            {
                if(listOfArg[1] == "~")
                {
                    Environment.CurrentDirectory = homePath;
                }
                else if(Directory.Exists(listOfArg[1]))
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
 