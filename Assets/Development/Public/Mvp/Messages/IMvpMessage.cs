namespace Development.Public.Mvp.Messages
{
    public interface IMvpMessage
    {
        T GetMessageType<T>();
    }
}