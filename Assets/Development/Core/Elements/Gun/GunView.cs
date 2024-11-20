using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.Gun
{
    [Serializable]
    public class GunView : BaseView<GunViewReferences>
    {
        public Camera MainCamera => ViewReferences.MainCamera;
    }
}