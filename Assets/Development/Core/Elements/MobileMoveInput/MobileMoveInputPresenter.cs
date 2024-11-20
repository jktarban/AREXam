using Cysharp.Threading.Tasks;
using Development.Public.Mvp;

namespace Development.Core.Elements.MobileMoveInput
{
    public class
        MobileMoveInputPresenter : BasePresenter<MobileMoveInputView, MobileMoveInputModel, MobileMoveInputEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.Camera);
            await UniTask.CompletedTask;
        }

        private void Update()
        {
            model.DetectMovement();
        }

        public override void Dispose()
        {
        }
    }
}