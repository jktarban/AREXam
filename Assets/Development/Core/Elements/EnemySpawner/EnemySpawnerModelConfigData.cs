using System;
using Development.Core.Components.Enemy;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerModelConfigData : BaseModelConfigData
    {
        public BaseEnemyComponent[] Enemies => enemies;
        public float YOffset => yOffset;

        [SerializeField] private BaseEnemyComponent[] enemies;
        [SerializeField] private float yOffset;
    }
}