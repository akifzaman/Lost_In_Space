using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 20.0f;
    //private float downBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        else if(gameObject.CompareTag("Background"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
