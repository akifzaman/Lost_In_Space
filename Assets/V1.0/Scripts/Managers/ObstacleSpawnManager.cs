using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public List<GameObject> obstacleList;
    public float obstacleSpawnDelay;

    void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 4);
        Instantiate(obstacleList[randomIndex], new Vector2(Random.Range(-2.3f, 2.3f), 7), obstacleList[randomIndex].transform.rotation);
    }
    IEnumerator ObstacleSpawn()
    {
        yield return new WaitForSeconds(obstacleSpawnDelay);
        if (GameManager.instance.isGameActive && GameManager.instance.timeCounter > 0)
        {
            Spawn();
        }

        StartCoroutine(ObstacleSpawn());
    }
}
