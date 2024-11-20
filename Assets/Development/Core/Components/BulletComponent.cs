using System.Collections;
using Development.Core.Enums;
using Development.Core.Interfaces;
using UnityEngine;

namespace Development.Core.Components
{
    public class BulletComponent : MonoBehaviour
    {
        private TargetType _targetType;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        public void SetTargetType(TargetType targetType)
        {
            _targetType = targetType;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(TagManager.Enemy))
            {
                collision.gameObject.GetComponent<ITarget>().Hit(_targetType);
            }
            
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.Enemy))
            {
                other.GetComponent<ITarget>().Hit(_targetType);
            }
            
            Destroy(gameObject);
        }
    }
}