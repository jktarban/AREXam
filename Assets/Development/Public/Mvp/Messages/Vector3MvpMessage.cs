using System;
using UnityEngine;

namespace Development.Public.Mvp.Messages
{
    [Serializable]
    public class Vector3MvpMessage : BaseMessage
    {
        public Vector3 Message;

        public Vector3MvpMessage(Vector3 message)
        {
            Message = message;
        }
    }
}