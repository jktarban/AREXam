
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameModel : BaseModel<GameModelConfigData,GameModelSettings>
    {
        public int EnemyKillCount => _enemyKill;
        
        private int _enemyKill;

        public void AddEnemyKill()
        {
            _enemyKill++;
        }
    }
}
