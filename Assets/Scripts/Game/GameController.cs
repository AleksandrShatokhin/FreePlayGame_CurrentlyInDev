using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private MeshCollider meshcol_ground;
    [SerializeField] private GameObject red_Enemy_Prefab;
    private Vector3 spawnPos;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(CoroutineSpawnEnemy());
    }

    IEnumerator CoroutineSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float posX = Random.Range(meshcol_ground.transform.position.x - Random.Range(0, meshcol_ground.bounds.extents.x), meshcol_ground.transform.position.x + Random.Range(0, meshcol_ground.bounds.extents.x));
        float posZ = Random.Range(meshcol_ground.transform.position.z - Random.Range(0, meshcol_ground.bounds.extents.z), meshcol_ground.transform.position.z + Random.Range(0, meshcol_ground.bounds.extents.z));

        spawnPos = new Vector3(posX, this.gameObject.transform.position.y, posZ);

        Instantiate(red_Enemy_Prefab, spawnPos, Quaternion.identity);
    }
}
