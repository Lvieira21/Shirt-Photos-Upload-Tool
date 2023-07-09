namespace TShirt.Photos.App.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string errorMessage)
        : base(errorMessage)
    {
    }

    public static void When(bool isInvalid, string message)
    {
        if (isInvalid)
        {
            throw new DomainException(message);
        }
    }
}
