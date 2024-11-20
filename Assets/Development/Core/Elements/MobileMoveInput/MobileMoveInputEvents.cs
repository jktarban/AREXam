using System;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputEvents : BaseEvents
    {
        public MVpEvent<BaseMessage> OnQuickMoveLeft => onQuickMoveLeft;
        public MVpEvent<BaseMessage> OnQuickMoveRight => onQuickMoveRight;
        public MVpEvent<BaseMessage> OnQuickMoveUp => onQuickMoveUp;
        public MVpEvent<BaseMessage> OnQuickMoveDown => onQuickMoveDown;
        public MVpEvent<BaseMessage> OnQuickMoveForward => onQuickMoveForward;

        [SerializeField] private MVpEvent<BaseMessage> onQuickMoveLeft;
        [SerializeField] private MVpEvent<BaseMessage> onQuickMoveRight;
        [SerializeField] private MVpEvent<BaseMessage> onQuickMoveUp;
        [SerializeField] private MVpEvent<BaseMessage> onQuickMoveDown;
        [SerializeField] private MVpEvent<BaseMessage> onQuickMoveForward;
    }
}