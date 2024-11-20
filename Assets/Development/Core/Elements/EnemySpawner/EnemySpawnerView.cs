using System;
using Development.Public.Mvp;
using UnityEngine.XR.ARFoundation;

namespace Development.Core.Elements.EnemySpawner
{
    [Serializable]
    public class EnemySpawnerView : BaseView<EnemySpawnerViewReferences>
    {
        public ARPlaneManager PlaneManager => ViewReferences.PlaneManager;
    }
}