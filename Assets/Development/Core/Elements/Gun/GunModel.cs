using System;
using Cysharp.Threading.Tasks;
using Development.Core.Components;
using Development.Core.Enums;
using Development.Core.Interfaces;
using Development.Public.Mvp;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Development.Core.Elements.Gun
{
    [Serializable]
    public class GunModel : BaseModel<GunModelConfigData, GunModelSettings>
    {
        private Camera _mainCamera;
        private ITarget _target;

        public void Init(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public void SetTarget(ITarget target)
        {
            _target = target;
        }

        public void Fire(TargetType targetType)
        {
            if (_target == null)
            {
                Debug.LogWarning("Target is not set. Cannot fire a homing bullet.");
                return;
            }

            switch (targetType)
            {
                case TargetType.LeftHip:
                    Fire(targetType, _target.LeftHip);
                    break;
                case TargetType.RightHip:
                    Fire(targetType, _target.RightHip);
                    break;
                case TargetType.Head:
                    Fire(targetType, _target.Head);
                    break;
                case TargetType.Feet:
                    Fire(targetType, _target.Feet);
                    break;
                case TargetType.Heart:
                    Fire(targetType, _target.Heart);
                    break;
            }
        }

        private void Fire(TargetType targetType, Transform target)
        {
            // Instantiate the bullet
            Vector3 firingDirection = (target.position - _mainCamera.transform.position).normalized;
            BulletComponent bullet = Object.Instantiate(ConfigData.BulletPrefab, _mainCamera.transform.position,
                Quaternion.LookRotation(firingDirection));
            bullet.SetTargetType(targetType);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // Start homing logic
            TrackTarget(target, bullet, rb).Forget();
        }

        private async UniTaskVoid TrackTarget(Transform target, BulletComponent bullet, Rigidbody rb)
        {
            float homingDuration = 5f; // Max duration for homing
            float homingSpeed = ConfigData.BulletSpeed;
            float timeElapsed = 0f;

            while (bullet != null && _target != null && timeElapsed < homingDuration)
            {
                // Calculate the new direction toward the target
                Vector3 directionToTarget = (target.position - bullet.transform.position).normalized;

                // Adjust velocity toward the target
                rb.linearVelocity = directionToTarget * homingSpeed;

                // Rotate the bullet to face the target
                bullet.transform.rotation = Quaternion.LookRotation(directionToTarget);

                // Wait for the next frame
                await UniTask.Yield();

                timeElapsed += Time.deltaTime;
            }
        }
    }
}