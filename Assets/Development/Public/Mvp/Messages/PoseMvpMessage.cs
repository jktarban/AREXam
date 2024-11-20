using System;
using UnityEngine;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class PoseMvpMessage : BaseMessage
    {
        public Pose Message;

        public PoseMvpMessage(Pose message)
        {
            Message = message;
        }
    }
}