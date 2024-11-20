using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.Gun
{
    [Serializable]
    public class GunViewReferences : BaseViewReferences
    {
        public Camera MainCamera => mainCamera;
        [SerializeField] private Camera mainCamera;
    }
}