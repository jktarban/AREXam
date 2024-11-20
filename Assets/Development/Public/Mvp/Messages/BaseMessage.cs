using System;

namespace Development.Public.Mvp.Messages
{
    public class BaseMessage : IMvpMessage
    {
        public int Id;

        public T GetMessageType<T>()
        {
            if (this is T message)
            {
                return message;
            }

            throw new InvalidCastException($"Cannot cast message of type '{GetType()}' to '{typeof(T)}'.");
        }
    }
}