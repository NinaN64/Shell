using System.IO;

public class CatCommand : DefaultCommand
{
    public string Name => "cat";

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
                else inQuotes = !inQuotes;
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
            try{
                StreamReader sr = new StreamReader(a);
                string? line = sr.ReadLine();

                while (line != null)
                {
                    Console.Write(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                // Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        //cat '/tmp/owl/f   34' '/tmp/owl/f   55' '/tmp/owl/f   31'
        
    }
}
