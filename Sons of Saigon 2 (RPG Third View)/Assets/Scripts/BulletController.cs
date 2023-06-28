using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
namespace CodeMonkey.HealthSystemCM
{
    public class BulletController : MonoBehaviour
    {
        private Rigidbody bulletRigidbody;
        private float bulletSpeed = 20f;
        
        // Start is called before the first frame update
        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
            
        }
        // Update is called once per frame
        void Start()
        {
           bulletRigidbody.velocity = transform.forward * bulletSpeed;
           
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyNavMesh enemy))
            {
                enemy.Damage(5);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
