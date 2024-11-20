using System;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine;

namespace Development.Core.Elements.TargetSelector
{
    [Serializable]
    public class TargetSelectorEvents : BaseEvents
    {
        public MVpEvent<TargetMvpMessage> OnTargetSelected => onTargetSelected;
        [SerializeField] MVpEvent<TargetMvpMessage> onTargetSelected;
    }
}