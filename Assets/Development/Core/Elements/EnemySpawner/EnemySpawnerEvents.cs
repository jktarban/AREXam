
using System;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerEvents : BaseEvents
    {
        public MVpEvent<BaseMessage> OnKillEnemy => onKillEnemy;
        [SerializeField] MVpEvent<BaseMessage> onKillEnemy;
    }
}
