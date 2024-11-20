using System;
using Development.Core.Components;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.Gun
{
    [Serializable]
    public class GunModelConfigData : BaseModelConfigData
    {
        public BulletComponent BulletPrefab => bulletPrefab;
        public float BulletSpeed => bulletSpeed;

        [SerializeField] private BulletComponent bulletPrefab;
        [SerializeField] private float bulletSpeed = 50f;
    }
}