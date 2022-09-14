using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSplashActivate : MonoBehaviour
{
    public GameObject superSplash;
    public Transform superSplashPositioin;
    public int superSplashCounter = 3;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && superSplashCounter > 0)
            {
                superSplashCounter--;
                Instantiate(superSplash, superSplash.transform.position, superSplash.transform.rotation);
            }
        }
    }
}
