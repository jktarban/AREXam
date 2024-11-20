using System;
using Development.Core.Enums;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputModel : BaseModel<MobileMoveInputModelConfigData, MobileMoveInputModelSettings>
    {
        private Vector3 _lastPosition;
        private Camera _camera;
        private bool _movementTriggered;
        private Action<TargetType> _onMoveDetected;

        public void Init(Camera camera, Action<TargetType> onMoveDetected)
        {
            _camera = camera;
            _lastPosition = _camera.transform.position;
            _movementTriggered = false;
            _onMoveDetected = onMoveDetected;
        }

        public void DetectMovement()
        {
            if (_camera == null) return;

            // Calculate position delta
            Vector3 currentPosition = _camera.transform.position;
            Vector3 deltaPosition = currentPosition - _lastPosition;

            // Transform deltaPosition into the camera's local space
            Vector3 localDelta = _camera.transform.InverseTransformDirection(deltaPosition);

            // Calculate velocity
            float deltaTime = Time.deltaTime;
            Vector3 velocity = localDelta / deltaTime;

            // Check if velocity exceeds threshold for quick movement
            if (!_movementTriggered && IsQuickMovement(velocity))
            {
                if (EvaluateMovement(velocity))
                {
                    _movementTriggered = true;
                }
            }

            // Reset movement trigger if velocity drops below a minimum
            if (_movementTriggered && velocity.magnitude < ConfigData.ResetVelocityThreshold)
            {
                _movementTriggered = false;
            }

            // Update last position
            _lastPosition = currentPosition;
        }

        private bool IsQuickMovement(Vector3 velocity)
        {
            return velocity.magnitude > ConfigData.VelocityThreshold;
        }

        private bool EvaluateMovement(Vector3 velocity)
        {
            if (CheckMovementDirection(velocity.x, ConfigData.MovementThreshold, TargetType.RightHip,
                    TargetType.LeftHip))
            {
                return true;
            }

            if (CheckMovementDirection(velocity.y, ConfigData.MovementThreshold, TargetType.Head, TargetType.Feet))
            {
                return true;
            }

            if (CheckMovementDirection(velocity.z, ConfigData.MovementThreshold, TargetType.Heart))
            {
                return true;
            }

            return false;
        }

        private bool CheckMovementDirection(float axisValue, float threshold, TargetType positiveTarget,
            TargetType? negativeTarget = null)
        {
            if (axisValue > threshold)
            {
                _onMoveDetected?.Invoke(positiveTarget);
                return true;
            }

            if (negativeTarget.HasValue && axisValue < -threshold)
            {
                _onMoveDetected?.Invoke(negativeTarget.Value);
                return true;
            }

            return false;
        }
    }
}