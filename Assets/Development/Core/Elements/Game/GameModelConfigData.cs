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
        public int GameTime => gameTime;

        [SerializeField] private AudioData gameAudio;
        [SerializeField] private int gameTime = 60;
    }
}