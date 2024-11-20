
using System;
using Development.Public.Mvp;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputViewReferences : BaseViewReferences
    {
        public Camera Camera => xrOrigin.Camera;
        [SerializeField] private XROrigin xrOrigin; 
    }
}
