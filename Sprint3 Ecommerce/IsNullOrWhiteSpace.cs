using System.Runtime.Serialization;

[Serializable]
internal class IsNullOrWhiteSpace : Exception
{
    public IsNullOrWhiteSpace()
    {
    }

    public IsNullOrWhiteSpace(string? message) : base(message)
    {
    }

    public IsNullOrWhiteSpace(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected IsNullOrWhiteSpace(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}