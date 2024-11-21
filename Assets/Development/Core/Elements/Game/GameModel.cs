using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Development.Public.Mvp;

namespace Development.Core.Elements.Game
{
    [Serializable]
    public class GameModel : BaseModel<GameModelConfigData, GameModelSettings>
    {
        public int EnemyKillCount => _enemyKill;
        private int _enemyKill;

        public void AddEnemyKill()
        {
            _enemyKill++;
        }

        public async UniTaskVoid StartTimer(Action<int> onTimeUpdate, Action onTimerEnd,
            CancellationToken cancellationToken)
        {
            int remainingTime = ConfigData.GameTime;
            onTimeUpdate?.Invoke(remainingTime);

            while (remainingTime > 0)
            {
                try
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationToken);

                    remainingTime--;
                    onTimeUpdate?.Invoke(remainingTime);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            if (remainingTime <= 0)
            {
                onTimerEnd?.Invoke();
            }
        }
    }
}