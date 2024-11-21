using Cysharp.Threading.Tasks;
using Development.Core.Enums;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;

namespace Development.Core.Elements.Gun
{
    public class GunPresenter : BasePresenter<GunView, GunModel, GunEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.MainCamera);
            await UniTask.CompletedTask;
        }

        public void SetTarget(TargetMvpMessage message)
        {
            model.SetTarget(message.Message);
        }

        public void FireLeft(BaseMessage message)
        {
            model.Fire(TargetType.LeftHip, CancellationToken);
        }

        public void FireRight(BaseMessage message)
        {
            model.Fire(TargetType.RightHip, CancellationToken);
        }

        public void FireUp(BaseMessage message)
        {
            model.Fire(TargetType.Head, CancellationToken);
        }

        public void FireDown(BaseMessage message)
        {
            model.Fire(TargetType.Feet, CancellationToken);
        }

        public void FireForward(BaseMessage message)
        {
            model.Fire(TargetType.Heart, CancellationToken);
        }

        public override void Dispose()
        {
        }
    }
}