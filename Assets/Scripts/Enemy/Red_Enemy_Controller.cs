using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Red_Enemy_Controller : MonoBehaviour, IDeathable
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

    void IDeathable.Kill()
    {
        GameController.GetInstance().GetReferencesToComponent().GetMainUIController().ChangeTextEnemyKills(1);
        Destroy(this.gameObject);
    }

    void IDeathable.TakeDamage(int damage)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ApplyDamageToPlayer(collision.gameObject);
        }
    }

    private void ApplyDamageToPlayer(GameObject player)
    {
        int damage = Random.Range(5, 10);

        player.GetComponent<HealthComponent>().ChangeHealth(damage);
    }
}
