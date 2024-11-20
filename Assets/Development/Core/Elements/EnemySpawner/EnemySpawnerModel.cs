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

        public void Init(ARPlaneManager planeManager)
        {
            _planeManager = planeManager;
            planeManager.trackablesChanged.AddListener(OnPlanesChanged);
        }

        private void OnPlanesChanged(ARTrackablesChangedEventArgs<ARPlane> args)
        {
            foreach (var plane in args.added)
            {
                // Modify the center position with an offset
                Vector3 planeCenter = plane.center;
                planeCenter.y += ConfigData.YOffset;

                // Instantiate the object on the modified position
                Object.Instantiate(ConfigData.Enemies[Random.Range(0, ConfigData.Enemies.Length)], planeCenter,
                    Quaternion.identity);
                break;
            }
        }

        public void Dispose()
        {
            _planeManager.trackablesChanged.RemoveListener(OnPlanesChanged);
            _planeManager = null;
        }
    }
}