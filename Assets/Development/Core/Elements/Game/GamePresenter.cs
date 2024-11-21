
using Cysharp.Threading.Tasks;
using Development.Public.Managers;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;

namespace Development.Core.Elements.Game
{
    public class GamePresenter : BasePresenter<GameView, GameModel, GameEvents>
    {
        protected override async UniTask InitPresenter()
        {
            AudioManager.Instance.PlayBgm(model.ConfigData.GameAudio).Forget();
            await UniTask.CompletedTask;
        }

        public void AddEnemyKill(BaseMessage message)
        {
            model.AddEnemyKill();
            view.UpdateEnemyKillCount(model.EnemyKillCount);
        }
        

        public override void Dispose()
        {
        }
    }
}
