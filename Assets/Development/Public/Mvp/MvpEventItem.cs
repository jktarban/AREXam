using System;
using UnityEngine.Events;

namespace Development.Public.Mvp
{
    [Serializable]
    public class MvpEventItem<T>
    {
        public float delay;
        public UnityEvent<T> unityEvent;
    }
}