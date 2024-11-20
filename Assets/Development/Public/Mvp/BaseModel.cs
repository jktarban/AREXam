using System;
using UnityEngine;

namespace Development.Public.Mvp
{
    [Serializable]
    public abstract class BaseModel<TModelConfigData, TModelSettings> : IModel
        where TModelConfigData : BaseModelConfigData
        where TModelSettings : BaseModelSettings
    {
        public TModelConfigData ConfigData => configData;
        public TModelSettings Settings => settings;

        [SerializeField] private TModelConfigData configData;
        [SerializeField] private TModelSettings settings;
    }
}