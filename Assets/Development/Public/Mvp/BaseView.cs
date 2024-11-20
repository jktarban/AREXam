using System;
using UnityEngine;

namespace Development.Public.Mvp
{
    [Serializable]
    public abstract class BaseView<TViewReferences> : IView
        where TViewReferences : BaseViewReferences
    {
        protected TViewReferences ViewReferences => viewReferences;

        [SerializeField] private TViewReferences viewReferences;
    }
}