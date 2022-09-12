using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public List<GameObject> obstacleList;
    public float obstacleSpawnDelay;

    private GameManager gameManager;
    // Start is called before the first frame update
   
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 4);
        Instantiate(obstacleList[randomIndex], new Vector2(Random.Range(-2.3f, 2.3f), 7), obstacleList[randomIndex].transform.rotation);
    }
    IEnumerator ObstacleSpawn()
    {
        yield return new WaitForSeconds(obstacleSpawnDelay);
        if (gameManager.isGameActive)
        {
            Spawn();
        }

        StartCoroutine(ObstacleSpawn());
    }
}
