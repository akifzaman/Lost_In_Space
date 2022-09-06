using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public bool isCollided = false;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Spawn()
    {
        Instantiate(enemy, new Vector2(Random.Range(-8, 8), 4), enemy.transform.rotation);
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(5);
        Spawn();
        StartCoroutine(EnemySpawn());
    }
    
}
