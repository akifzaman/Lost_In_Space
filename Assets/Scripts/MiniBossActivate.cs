using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossActivate : MonoBehaviour
{
    private float speed = 1f;
    //public bool miniBossActive = false;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timeCounter <= -8)
        {
            if (transform.position.y < 4.0f)
            {
                speed = 0.0f;
                gameManager.miniBossActive = true;
            }
            if (transform.position.y > 4.0f)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
    }
}
