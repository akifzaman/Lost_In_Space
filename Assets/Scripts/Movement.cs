using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
 
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
