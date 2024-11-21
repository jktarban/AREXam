using System;
using Development.Public.Mvp;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerModel : BaseModel<EnemySpawnerModelConfigData, EnemySpawnerModelSettings>
    {
        private ARPlaneManager _planeManager;
        private Action _onKillEnemy;

        public void Init(ARPlaneManager planeManager, Action onKillEnemy)
        {
            _planeManager = planeManager;
            _planeManager.trackablesChanged.AddListener(OnPlanesChanged);
            _onKillEnemy = onKillEnemy;
        }

        private void OnPlanesChanged(ARTrackablesChangedEventArgs<ARPlane> args)
        {
            foreach (var plane in args.added)
            {
                // Modify the center position with an offset
                Vector3 planeCenter = plane.center;
                planeCenter.y += ConfigData.YOffset;

                // Instantiate the object on the modified position
                var enemy = Object.Instantiate(ConfigData.Enemies[Random.Range(0, ConfigData.Enemies.Length)],
                    planeCenter,
                    Quaternion.identity);
                enemy.OnKillEnemy(_onKillEnemy);
                break;
            }
        }

        public void Dispose()
        {
            _planeManager.trackablesChanged.RemoveListener(OnPlanesChanged);
            _planeManager = null;
        }

        public void Stop()
        {
            _planeManager.trackablesChanged.RemoveAllListeners();
        }
    }
}