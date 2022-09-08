using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Red_Enemy_Controller : MonoBehaviour
{
    private NavMeshAgent agent_Enemy;

    private Transform targetPlayer;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        agent_Enemy = this.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        agent_Enemy.SetDestination(targetPlayer.position);
    }
}
