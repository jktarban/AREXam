using System;
using Development.Core.Components.Enemy;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerModelConfigData : BaseModelConfigData
    {
        public BaseEnemyComponent Enemy => enemy;
        public float YOffset => yOffset;

        [SerializeField] private BaseEnemyComponent enemy;
        [SerializeField] private float yOffset;
    }
}