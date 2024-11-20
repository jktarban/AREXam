using System;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class BoolMvpMessage : BaseMessage
    {
        public bool Message;

        public BoolMvpMessage(bool message)
        {
            Message = message;
        }
    }
}