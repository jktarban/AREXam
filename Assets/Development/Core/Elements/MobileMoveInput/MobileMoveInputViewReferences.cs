using System;
using Development.Public.Mvp;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputViewReferences : BaseViewReferences
    {
        public Camera Camera => xrOrigin.Camera;
        public TMP_Text InputText => inputText;
        [SerializeField] private XROrigin xrOrigin;
        [SerializeField] private TMP_Text inputText;
    }
}