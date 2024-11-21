using System;
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
        public Renderer Renderer => renderer;

        [SerializeField] private bool isRandomWeakpoint;
        [SerializeField] private TargetType weakPoint;
        [SerializeField] private Transform leftHip;
        [SerializeField] private Transform rightHip;
        [SerializeField] private Transform head;
        [SerializeField] private Transform feet;
        [SerializeField] private Transform heart;
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private Renderer renderer;
        [SerializeField] private GameObject destroyEffect;
        private TargetType _weakPoint;


        private void Start()
        {
            OnStart();
            if (isRandomWeakpoint)
            {
                // Dynamically calculate the count of TargetType enum members
                Array enumValues = Enum.GetValues(typeof(TargetType));
                int randomIndex = UnityEngine.Random.Range(0, enumValues.Length);
                _weakPoint = (TargetType)enumValues.GetValue(randomIndex);
            }
            else
            {
                _weakPoint = weakPoint;
            }
        }

        public void ShowParticle(bool isShow)
        {
            particleSystem.gameObject.SetActive(isShow);
        }

        public void Hit(TargetType targetType)
        {
            if (targetType == _weakPoint)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        protected abstract void OnStart();
    }
}