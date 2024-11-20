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
            model.Fire(TargetType.LeftHip);
        }

        public void FireRight(BaseMessage message)
        {
            model.Fire(TargetType.RightHip);
        }

        public void FireUp(BaseMessage message)
        {
            model.Fire(TargetType.Head);
        }

        public void FireDown(BaseMessage message)
        {
            model.Fire(TargetType.Feet);
        }

        public void FireForward(BaseMessage message)
        {
            model.Fire(TargetType.Heart);
        }
        
        public override void Dispose()
        {
        }
    }
}