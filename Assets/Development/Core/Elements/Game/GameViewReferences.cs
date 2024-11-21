using System;
using Development.Public.Mvp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameViewReferences : BaseViewReferences
    {
        public TMP_Text EnemyKillCountText => enemyKillCountText;
        public TMP_Text TimerText => timerText;
        public GameObject TimeUp => timeUp;
        public Button RetryButton => retryButton;

        [SerializeField] private TMP_Text enemyKillCountText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject timeUp;
        [SerializeField] private Button retryButton;
    }
}