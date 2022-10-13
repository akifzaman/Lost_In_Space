using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class StarSpawner : MonoBehaviour
{
    public List<GameObject> starList;

    private EnemyController enemyController;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(Vector2 pos)
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(starList[i], pos, starList[i].transform.rotation);
        }
    }
}
