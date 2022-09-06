using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<GameObject> enemyList;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 3);
        Instantiate(enemyList[randomIndex], new Vector2(Random.Range(-8, 8), 7), enemyList[randomIndex].transform.rotation);
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(3);
        Spawn();
        StartCoroutine(EnemySpawn());
    }
    
}
