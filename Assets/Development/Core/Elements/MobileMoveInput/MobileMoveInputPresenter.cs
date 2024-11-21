using Cysharp.Threading.Tasks;
using Development.Core.Enums;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;

namespace Development.Core.Elements.MobileMoveInput
{
    public class
        MobileMoveInputPresenter : BasePresenter<MobileMoveInputView, MobileMoveInputModel, MobileMoveInputEvents>
    {
        protected override async UniTask InitPresenter()
        {
            model.Init(view.Camera, OnMoveDetected);
            await UniTask.CompletedTask;
        }

        public void Stop(BaseMessage message)
        {
            model.Stop();
        }

        private void OnMoveDetected(TargetType targetType)
        {
            var inputText = "Input: ";
            switch (targetType)
            {
                case TargetType.LeftHip:
                    events.OnQuickMoveLeft?.Invoke(new BaseMessage(), CancellationToken);
                    inputText += "Left";
                    break;
                case TargetType.RightHip:
                    events.OnQuickMoveRight?.Invoke(new BaseMessage(), CancellationToken);
                    inputText += "Right";
                    break;
                case TargetType.Head:
                    events.OnQuickMoveUp?.Invoke(new BaseMessage(), CancellationToken);
                    inputText += "Up";
                    break;
                case TargetType.Feet:
                    events.OnQuickMoveDown?.Invoke(new BaseMessage(), CancellationToken);
                    inputText += "Down";
                    break;
                case TargetType.Heart:
                    events.OnQuickMoveForward?.Invoke(new BaseMessage(), CancellationToken);
                    inputText += "Forward";
                    break;
            }
            
            view.ShowInputText(inputText);
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