public class EchoCommand : DefaultCommand
{
    public string Name => "echo";

    public void RunCommand(string arg)
    {
        bool inQuotes = false;
        
        string current = "";
        List<string> ListOfArgs = new List<string>();

        foreach (char a in arg)
        {
            if (a == '\'')
            {
                if (!inQuotes)
                {
                    inQuotes = true;
                }
                continue;
            }
            if (a == ' ' && !inQuotes)
            {
                if (current.Length > 0)
                {
                    ListOfArgs.Add(current);
                    current = "";
                }
                continue;
            }
            current += a;
        }

        if (current.Length > 0)
        {
            ListOfArgs.Add(current);
        }

        foreach (var a in ListOfArgs)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine();
    }
}
