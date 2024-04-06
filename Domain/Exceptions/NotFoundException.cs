namespace Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string entityName) :
        base($"this {entityName} not found")
    { }
}
