using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    //[SerializeField]private float boundary = 10.0f;
    [SerializeField] private float xBoundary = 3.20f;
    [SerializeField] private float yBoundary = -5.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < yBoundary)
        {
            Destroy(gameObject);
        }
    }
}
