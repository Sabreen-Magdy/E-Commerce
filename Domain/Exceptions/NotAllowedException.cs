

namespace Domain.Exceptions
{
    public class NotAllowedException : Exception
    {
        public NotAllowedException(string mess) :
        base(mess)
        { }
    }
}
