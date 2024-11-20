using Cysharp.Threading.Tasks;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;

namespace Development.Core.Elements.TargetSelector
{
    public class TargetSelectorPresenter : BasePresenter<TargetSelectorView, TargetSelectorModel, TargetSelectorEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.Camera);
            await UniTask.CompletedTask;
        }

        private void Update()
        {
            var target = model.FindVisibleEnemy();
            if (target == null)
            {
                return;
            }

            events.OnTargetSelected?.Invoke(new TargetMvpMessage(target), CancellationToken);
        }

        public override void Dispose()
        {
        }
    }
}