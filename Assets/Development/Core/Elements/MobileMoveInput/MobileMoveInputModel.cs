using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputModel : BaseModel<MobileMoveInputModelConfigData, MobileMoveInputModelSettings>
    {
        private Vector3 _lastPosition;
        private Vector3 _lastVelocity;
        private float _lastActionTime;
        private Camera _camera;
        private bool _movementTriggered;

        public void Init(Camera camera)
        {
            _camera = camera;
            _lastPosition = _camera.transform.position;
            _lastActionTime = Time.time;
            _movementTriggered = false;
        }

        public void DetectMovement()
        {
            if (_camera == null)
                return;

            // Calculate position delta
            Vector3 currentPosition = _camera.transform.position;
            Vector3 deltaPosition = currentPosition - _lastPosition;

            // Transform deltaPosition into the camera's local space
            Vector3 localDelta = _camera.transform.InverseTransformDirection(deltaPosition);

            // Calculate velocity
            float deltaTime = Time.deltaTime;
            Vector3 velocity = localDelta / deltaTime;

            // Check if velocity exceeds threshold for quick movement
            if (!_movementTriggered && velocity.magnitude > ConfigData.VelocityThreshold)
            {
                string direction = GetMovementDirection(velocity);

                if (!string.IsNullOrEmpty(direction))
                {
                    TriggerAction(direction);
                    _movementTriggered = true;
                    _lastActionTime = Time.time;
                }
            }

            // Reset movement trigger if velocity drops below a minimum
            if (_movementTriggered && velocity.magnitude < ConfigData.ResetVelocityThreshold)
            {
                _movementTriggered = false;
            }

            // Update last position and velocity
            _lastPosition = currentPosition;
            _lastVelocity = velocity;
        }

        private string GetMovementDirection(Vector3 velocity)
        {
            // Determine dominant movement direction based on velocity
            if (velocity.x > ConfigData.MovementThreshold) return "Right";
            if (velocity.x < -ConfigData.MovementThreshold) return "Left";
            if (velocity.y > ConfigData.MovementThreshold) return "Up";
            if (velocity.y < -ConfigData.MovementThreshold) return "Down";
            if (velocity.z > ConfigData.MovementThreshold) return "Forward";

            return null;
        }

        private void TriggerAction(string direction)
        {
            Debug.Log($"Quick movement detected: {direction}");
            // Add your custom logic for each direction here
        }
    }
}