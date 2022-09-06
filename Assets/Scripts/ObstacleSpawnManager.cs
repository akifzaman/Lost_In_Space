using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public List<GameObject> obstacleList;
    // Start is called before the first frame update
   
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 4);
        Instantiate(obstacleList[randomIndex], new Vector2(Random.Range(-8, 8), 7), obstacleList[randomIndex].transform.rotation);
    }
    IEnumerator ObstacleSpawn()
    {
        yield return new WaitForSeconds(5);
        Spawn();
        StartCoroutine(ObstacleSpawn());
    }
}
