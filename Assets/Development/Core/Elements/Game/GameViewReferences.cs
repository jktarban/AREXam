using System;
using Development.Public.Mvp;
using TMPro;
using UnityEngine;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameViewReferences : BaseViewReferences
    {
        public TMP_Text EnemyKillCountText => enemyKillCountText;

        [SerializeField] private TMP_Text enemyKillCountText;
    }
}