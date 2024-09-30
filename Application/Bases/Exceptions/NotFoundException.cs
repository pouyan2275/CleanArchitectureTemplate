namespace Application.Bases.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, string key) : base($"{name} ({key}) was not found")
    {
        
    }
}
