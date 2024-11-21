
using Cysharp.Threading.Tasks;
using Development.Public.Managers;
using Development.Public.Mvp;

namespace Development.Core.Elements.Game
{
    public class GamePresenter : BasePresenter<GameView, GameModel, GameEvents>
    {
        protected override async UniTask InitPresenter()
        {
            AudioManager.Instance.PlayBgm(model.ConfigData.GameAudio).Forget();
            await UniTask.CompletedTask;
        }
        
        

        public override void Dispose()
        {
        }
    }
}
