using System;
using Development.Public.Mvp;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Development.Core.Elements.Gun
{
    [Serializable]
    public class GunViewReferences : BaseViewReferences
    {
        public Camera MainCamera => xrOrigin.Camera;
        [SerializeField] private XROrigin xrOrigin;
    }
}