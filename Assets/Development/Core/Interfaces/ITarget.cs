using Development.Core.Enums;
using UnityEngine;

namespace Development.Core.Interfaces
{
    public interface ITarget
    {
        Transform LeftHip { get; }
        Transform RightHip { get; }
        Transform Head { get; }
        Transform Feet { get; }
        Transform Heart { get; }
        void Hit(TargetType targetType);
    }
}