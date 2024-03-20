namespace Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException() :
        base("this Customer not found")
    { }
}
