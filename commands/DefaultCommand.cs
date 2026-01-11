
public interface DefaultCommand
{
    string Name { get; }
    void RunCommand(string arg);
}