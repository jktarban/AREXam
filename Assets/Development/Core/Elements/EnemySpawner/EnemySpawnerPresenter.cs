using Cysharp.Threading.Tasks;
using Development.Public.Mvp;

namespace Development.Core.Elements.EnemySpawner
{
    public class EnemySpawnerPresenter : BasePresenter<EnemySpawnerView, EnemySpawnerModel, EnemySpawnerEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.PlaneManager);
            await UniTask.CompletedTask;
        }

        public override void Dispose()
        {
        }
    }
}