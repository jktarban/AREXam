using System;
using UnityEngine;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class TransformMvpMessage : BaseMessage
    {
        public Transform Message;

        public TransformMvpMessage(Transform message)
        {
            Message = message;
        }
    }
}