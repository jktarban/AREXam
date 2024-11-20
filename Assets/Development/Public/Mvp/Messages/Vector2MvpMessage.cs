using System;
using UnityEngine;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class Vector2MvpMessage : BaseMessage
    {
        public Vector2 Message;

        public Vector2MvpMessage(Vector2 message)
        {
            Message = message;
        }
    }
}