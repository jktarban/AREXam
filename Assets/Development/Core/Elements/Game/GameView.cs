using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameView : BaseView<GameViewReferences>
    {
        public void OnRetryButtonClicked(Action onRetryButtonClicked)
        {
            ViewReferences.RetryButton.onClick.AddListener(delegate { onRetryButtonClicked(); });
        }

        public void UpdateEnemyKillCount(int modelEnemyKillCount)
        {
            ViewReferences.EnemyKillCountText.text = "Kill Count: " + modelEnemyKillCount;
        }

        public void UpdateTimer(int time)
        {
            ViewReferences.TimerText.text = time.ToString();
        }

        public void ShowTimeUp()
        {
            ViewReferences.TimeUp.SetActive(true);
        }
    }
}