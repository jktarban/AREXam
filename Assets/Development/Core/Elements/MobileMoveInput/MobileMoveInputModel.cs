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
        private bool _isStopped;

        public void Init(Camera camera, Action<TargetType> onMoveDetected)
        {
            _camera = camera;
            _lastPosition = _camera.transform.position;
            _movementTriggered = false;
            _onMoveDetected = onMoveDetected;
        }

        public void DetectMovement()
        {
            if (_isStopped)
            {
                return;
            }
            
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
                TargetType? detectedMovement = GetDominantMovement(velocity);

                if (detectedMovement.HasValue)
                {
                    _onMoveDetected?.Invoke(detectedMovement.Value);
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

        private TargetType? GetDominantMovement(Vector3 velocity)
        {
            // Calculate absolute values to find dominant axis
            float absX = Mathf.Abs(velocity.x);
            float absY = Mathf.Abs(velocity.y);
            float absZ = Mathf.Abs(velocity.z);

            // Compare magnitudes to determine the dominant movement direction
            if (absX > absY && absX > absZ && absX > ConfigData.MovementThreshold)
            {
                return velocity.x > 0 ? TargetType.RightHip : TargetType.LeftHip;
            }

            if (absY > absX && absY > absZ && absY > ConfigData.MovementThreshold)
            {
                return velocity.y > 0 ? TargetType.Head : TargetType.Feet;
            }

            if (absZ > absX && absZ > absY && absZ > ConfigData.MovementThreshold)
            {
                return velocity.z > 0 ? TargetType.Heart : null; // Only forward for Z axis
            }

            return null; // No significant movement
        }

        public void Stop()
        {
            _isStopped = true;
        }
    }
}