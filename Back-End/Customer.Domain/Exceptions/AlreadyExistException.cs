namespace Customer.Domain.Exceptions;

public sealed class AlreadyExistException : Exception
{
    public AlreadyExistException() :
    base("this Customer already exist")
    { }
}
