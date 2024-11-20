using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.TargetSelector
{
    [Serializable]
    public class TargetSelectorView : BaseView<TargetSelectorViewReferences>
    {
        public Camera Camera => ViewReferences.Camera;
    }
}