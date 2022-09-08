using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<GameObject> enemyList;
    public float enemySpawnDelay;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 3);
        Instantiate(enemyList[randomIndex], new Vector2(Random.Range(-2.3f, 2.3f), 6), enemyList[randomIndex].transform.rotation);
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(enemySpawnDelay);
        Spawn();
        StartCoroutine(EnemySpawn());
    }
    
}
