
public class PathFinder
{
    private List<string>? pathVariable = new List<string>();

    public PathFinder()
    {
        pathVariable = Environment.GetEnvironmentVariable("PATH")?.Split(':').ToList();
    }
    public string? checkFullPath (string argument)
    {
        string? firstOrDefault = null;
        if (pathVariable == null) return firstOrDefault;
        foreach (var path in pathVariable)
        {
            string fullPath = path + "/" + argument;
            if (!File.Exists(fullPath))
                continue;

            var mode = File.GetUnixFileMode(fullPath); //how to make Windows version?
            if ((mode & UnixFileMode.UserExecute) != 0)
            {
                firstOrDefault = fullPath;
                break;
            }
        }
        return firstOrDefault;
    }

}