using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float boundary = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("bullet_lvl1") && transform.position.y > boundary)
        {
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy") && transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("EnemyBullet") && transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
        
    }
}
