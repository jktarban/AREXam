using System;
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.MobileMoveInput
{
    [Serializable]
    public class MobileMoveInputModelConfigData : BaseModelConfigData
    {
        public float MovementThreshold => movementThreshold;
        public float VelocityThreshold => velocityThreshold;  // For quick movement detection
        public float ResetVelocityThreshold => resetVelocityThreshold;  // For reset detection after stop

        [SerializeField] private float movementThreshold = 0.5f; // Sensitivity for directional movement detection
        [SerializeField] private float velocityThreshold = 1.5f; // Minimum velocity magnitude for detecting quick movements
        [SerializeField] private float resetVelocityThreshold = 0.2f; // Velocity below which reset triggers are allowed
    }
}