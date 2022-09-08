using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_Player;

    [SerializeField] private GameObject fireBall_Prefab;

    // параметры игрока
    [SerializeField] private float speed_Player;

    // параметры для атаки врагов
    [SerializeField] private float delayTimeSearchEnemy;
    [SerializeField] private float radiusForSerachEnemy;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float distanceToEnemy = 0.0f;

    void Start()
    {
        rb_Player = this.GetComponent<Rigidbody>();

        StartCoroutine(SearchEnemyForAttacking());
    }

    void FixedUpdate()
    {
        MovementPlayer();
    }

    void MovementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb_Player.MovePosition(transform.position + movement * speed_Player / 16);

        if (Vector3.Angle(Vector3.forward, movement) > 1.0f || Vector3.Angle(Vector3.forward, movement) == 0.0f)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, movement, speed_Player, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    IEnumerator SearchEnemyForAttacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTimeSearchEnemy);
            SearchEnemy();
        }
    }

    private void SearchEnemy()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, radiusForSerachEnemy);

        foreach (Collider hit in hitCollider)
        {
            if (hit.gameObject.layer == (int)Layers.Enemy)
            {
                enemies.Add(hit.gameObject);
            }
        }

        if (enemies.Count == 1)
        {
            FireBall_Shot(enemies[0]);
        }

        if (enemies.Count > 1)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (distanceToEnemy == 0.0f)
                {
                    distanceToEnemy = Vector3.Distance(enemies[i].transform.position, this.transform.position);
                }
                else
                {
                    float distanceToEnemyNEW = Vector3.Distance(enemies[i].transform.position, this.transform.position);

                    if (distanceToEnemyNEW > distanceToEnemy)
                    {
                        enemies.RemoveAt(i);
                    }
                    else
                    {
                        enemies.RemoveAt(i - 1);
                    }
                }
            }

            FireBall_Shot(enemies[0]);
        }
    }

    private GameObject FireBall_Shot(GameObject enemy)
    {
        ClearCounterEnemy();

        Vector3 spawnFireBallPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        Vector3 relativePos = enemy.transform.position - spawnFireBallPosition;
        Quaternion rotationFireBall = Quaternion.LookRotation(relativePos, Vector3.up);

        GameObject fireball = Instantiate(fireBall_Prefab, spawnFireBallPosition, rotationFireBall);

        return fireball;
    }

    private void ClearCounterEnemy()
    {
        distanceToEnemy = 0.0f;
        enemies.Clear();
    }
}
