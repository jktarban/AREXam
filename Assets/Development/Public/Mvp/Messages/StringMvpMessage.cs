using System;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class StringMvpMessage : BaseMessage
    {
        public string Message;

        public StringMvpMessage(string message)
        {
            Message = message;
        }
    }
}