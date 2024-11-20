using System;
using Development.Public.Mvp;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Development.Core.Elements.TargetSelector
{
    [Serializable]
    public class TargetSelectorViewReferences : BaseViewReferences
    {
        public Camera Camera => xrOrigin.Camera;
        [SerializeField] private XROrigin xrOrigin; 
    }
}