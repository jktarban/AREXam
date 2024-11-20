using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.TargetSelector
{
    [Serializable]
    public class TargetSelectorViewReferences : BaseViewReferences
    {
        public Camera Camera => camera;
        [SerializeField] private Camera camera; 
    }
}