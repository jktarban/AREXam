using System;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameEvents : BaseEvents
    {
        public MVpEvent<BaseMessage> OnGameOver => onGameOver;
        [SerializeField] MVpEvent<BaseMessage> onGameOver;
    }
}