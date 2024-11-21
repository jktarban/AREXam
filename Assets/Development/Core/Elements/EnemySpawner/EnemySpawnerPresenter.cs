using Cysharp.Threading.Tasks;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;

namespace Development.Core.Elements.EnemySpawner
{
    public class EnemySpawnerPresenter : BasePresenter<EnemySpawnerView, EnemySpawnerModel, EnemySpawnerEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.PlaneManager, OnKillEnemy);
            await UniTask.CompletedTask;
        }

        public void Stop(BaseMessage message)
        {
            model.Stop();
        }

        private void OnKillEnemy()
        {
            events.OnKillEnemy?.Invoke(new BaseMessage(), CancellationToken);
        }

        public override void Dispose()
        {
        }
    }
}