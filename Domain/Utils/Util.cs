using Domain.Exceptions;

namespace Domain.Utils;

public static class Util
{
    public static void ThrowExceptionIfItIsEmpty(Object o, string message)
    {
        if (o == null)
        {
            throw new ElementoInvalidoException(message);
        }
    }

    public static void ThrowExceptionIfEmptyString(string s, string message)
    {
        if (String.IsNullOrEmpty(s))
        {
            throw new ElementoInvalidoException(message);
        }
    }

    public static void ThrowExceptionIfNegativeNumber(decimal number, string message)
    {
        if (number < 0)
        {
            throw new ElementoInvalidoException(message);
        }
    }

    public static void ThrowExceptionIfFutureDate(DateTime dateTime, string message)
    {
        if (dateTime > DateTime.Now)
        {
            throw new ElementoInvalidoException(message);
        }
    }
    
    
    public static void ThrowExceptionIfZero(int number, string message)
    {
        if (number == 0)
        {
            throw new ElementoInvalidoException(message);
        }
    }
}