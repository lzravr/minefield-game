using System.Runtime.Serialization;

namespace Minefield.Game.Exceptions;
[Serializable]
public class YouExploadedException : Exception
{
    public YouExploadedException()
    {
    }

    public YouExploadedException(string? message) : base(message)
    {
    }

    public YouExploadedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected YouExploadedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}