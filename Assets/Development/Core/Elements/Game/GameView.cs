using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameView : BaseView<GameViewReferences>
    {
        public void UpdateEnemyKillCount(int modelEnemyKillCount)
        {
            ViewReferences.EnemyKillCountText.text = "Kill Count: " +modelEnemyKillCount;
        }
    }
}