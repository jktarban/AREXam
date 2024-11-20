using System;
using Development.Public.Mvp;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerViewReferences : BaseViewReferences
    {
        public ARPlaneManager PlaneManager => planeManager;
        [SerializeField] private ARPlaneManager planeManager;
    }
}