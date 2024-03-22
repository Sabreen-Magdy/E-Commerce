namespace Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string v) :
        base("this Customer not found")
    { }
}
