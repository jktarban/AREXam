using System;
using Development.Core.Components.Enemy;
using Development.Public.Mvp;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Development.Core.Elements.TargetSelector
{
    [Serializable]
    public class TargetSelectorModel : BaseModel<TargetSelectorModelConfigData, TargetSelectorModelSettings>
    {
        private BaseEnemyComponent _currentTarget;
        private Camera _camera;

        public void Init(Camera camera)
        {
            _camera = camera;
        }

        public BaseEnemyComponent FindVisibleEnemy()
        {
            // Get all enemies in the scene
            BaseEnemyComponent[] enemies =
                Object.FindObjectsByType<BaseEnemyComponent>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            BaseEnemyComponent newTarget = null;
            float smallestDistance = float.MaxValue;

            foreach (var enemy in enemies)
            {
                Renderer enemyRenderer = enemy.GetComponent<Renderer>();
                if (enemyRenderer == null || !enemyRenderer.isVisible)
                    continue;

                // Check if enemy is within the camera's view
                Vector3 screenPoint = _camera.WorldToViewportPoint(enemy.transform.position);
                bool isInView = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1 &&
                                screenPoint.z > 0;

                if (isInView)
                {
                    // Calculate the distance from the center of the camera's viewport
                    Vector2 screenCenter = new Vector2(0.5f, 0.5f);
                    Vector2 enemyScreenPosition = new Vector2(screenPoint.x, screenPoint.y);
                    float distanceToCenter = Vector2.Distance(screenCenter, enemyScreenPosition);

                    // Update the target if this enemy is closer to the center
                    if (distanceToCenter < smallestDistance)
                    {
                        smallestDistance = distanceToCenter;
                        newTarget = enemy;
                    }
                }
            }

            // Update the target if a new one is found
            if (newTarget != _currentTarget)
            {
                if (_currentTarget != null)
                {
                    _currentTarget.ShowParticle(false);
                }
                _currentTarget = newTarget;
                _currentTarget.ShowParticle(true);
                OnTargetChanged(_currentTarget);
            }

            return _currentTarget;
        }

        private void OnTargetChanged(BaseEnemyComponent newTarget)
        {
            if (newTarget != null)
            {
                Debug.Log($"New target selected: {newTarget.name}");
                // Add any logic to handle targeting (e.g., highlight enemy)
            }
        }
    }
}