using Development.Core.Enums;
using Development.Core.Interfaces;
using UnityEngine;

namespace Development.Core.Components.Enemy
{
    public abstract class BaseEnemyComponent : MonoBehaviour, ITarget
    {
        public Transform LeftHip => leftHip;
        public Transform RightHip => rightHip;
        public Transform Head => head;
        public Transform Feet => feet;
        public Transform Heart => heart;

        [SerializeField] private TargetType weakPoint;
        [SerializeField] private Transform leftHip;
        [SerializeField] private Transform rightHip;
        [SerializeField] private Transform head;
        [SerializeField] private Transform feet;
        [SerializeField] private Transform heart;
        [SerializeField] private ParticleSystem _particleSystem;


        private void Start()
        {
            OnStart();
        }

        public void ShowParticle(bool isShow)
        {
            _particleSystem.gameObject.SetActive(isShow);
        }

        public void Hit(TargetType targetType)
        {
            if (targetType == weakPoint)
            {
                Destroy(gameObject);
            }
        }

        protected abstract void OnStart();
    }
}