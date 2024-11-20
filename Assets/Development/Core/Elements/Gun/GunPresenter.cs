using Cysharp.Threading.Tasks;
using Development.Core.Enums;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine.InputSystem;

namespace Development.Core.Elements.Gun
{
    public class GunPresenter : BasePresenter<GunView, GunModel, GunEvents>
    {
#if UNITY_EDITOR
        private InputAction _leftAction;
        private InputAction _rightAction;
        private InputAction _upAction;
        private InputAction _downAction;
        private InputAction _forwardAction;
#endif

        protected override async UniTask InitPresenter()
        {
            model.Init(view.MainCamera);
#if UNITY_EDITOR
            _leftAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/leftArrow");
            _upAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/upArrow");
            _downAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/downArrow");
            _rightAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/rightArrow");
            _forwardAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/leftShift");

            _leftAction.performed += OnLeftActionPerformed;
            _upAction.performed += OnUpActionPerformed;
            _downAction.performed += OnDownActionPerformed;
            _rightAction.performed += OnRightActionPerformed;
            _forwardAction.performed += OnForwardActionPerformed;

            _leftAction.Enable();
            _upAction.Enable();
            _downAction.Enable();
            _rightAction.Enable();
            _forwardAction.Enable();
#endif
            await UniTask.CompletedTask;
        }

        public void SetTarget(TargetMvpMessage message)
        {
            model.SetTarget(message.Message);
        }

#if UNITY_EDITOR

        private void OnLeftActionPerformed(InputAction.CallbackContext obj)
        {
            model.Fire(TargetType.LeftHip);
        }

        private void OnUpActionPerformed(InputAction.CallbackContext obj)
        {
            model.Fire(TargetType.Head);
        }

        private void OnDownActionPerformed(InputAction.CallbackContext obj)
        {
            model.Fire(TargetType.Feet);
        }

        private void OnRightActionPerformed(InputAction.CallbackContext obj)
        {
            model.Fire(TargetType.RightHip);
        }

        private void OnForwardActionPerformed(InputAction.CallbackContext obj)
        {
            model.Fire(TargetType.Heart);
        }
#endif

        private void FireLeft(BaseMessage message)
        {
            model.Fire(TargetType.LeftHip);
        }

        private void FireRight(BaseMessage message)
        {
            model.Fire(TargetType.RightHip);
        }

        private void FireUp(BaseMessage message)
        {
            model.Fire(TargetType.Head);
        }

        private void FireDown(BaseMessage message)
        {
            model.Fire(TargetType.Feet);
        }

        private void FireForward(BaseMessage message)
        {
            model.Fire(TargetType.Heart);
        }


        public override void Dispose()
        {
#if UNITY_EDITOR
            _leftAction.performed -= OnLeftActionPerformed;
            _upAction.performed -= OnLeftActionPerformed;
            _rightAction.performed -= OnLeftActionPerformed;
            _downAction.performed -= OnLeftActionPerformed;
            _forwardAction.performed -= OnLeftActionPerformed;

            _leftAction.Dispose();
            _upAction.Dispose();
            _rightAction.Dispose();
            _downAction.Dispose();
            _forwardAction.Dispose();
#endif
        }
    }
}