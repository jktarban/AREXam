using System;
using Development.Public.Managers;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameModelConfigData : BaseModelConfigData
    {
        public AudioData GameAudio => gameAudio;
        [SerializeField] private AudioData gameAudio;
    }
}