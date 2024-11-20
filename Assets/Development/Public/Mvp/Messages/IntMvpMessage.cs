using System;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class IntMvpMessage : BaseMessage
    {
        public int Message;

        public IntMvpMessage(int message)
        {
            Message = message;
        }
    }
}