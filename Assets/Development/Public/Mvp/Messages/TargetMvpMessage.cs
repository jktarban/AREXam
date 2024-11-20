using System;
using Development.Core.Interfaces;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class TargetMvpMessage : BaseMessage
    {
        public ITarget Message;

        public TargetMvpMessage(ITarget message)
        {
            Message = message;
        }
    }
}