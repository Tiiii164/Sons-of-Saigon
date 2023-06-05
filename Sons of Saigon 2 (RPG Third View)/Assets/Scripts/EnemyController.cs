using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] float moveSpeed = 5f;

    [SerializeField] Transform playerPosition;
    
    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    

    private void Update()
    {
        
        navMeshAgent.destination = playerPosition.position;
        //transform.Rotate(transform.rotation.x,transform.rotation.y-180,transform.rotation.z);
    }
}
