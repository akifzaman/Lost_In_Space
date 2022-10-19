using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    [SerializeField] private float xBoundary = 3.20f;
    [SerializeField] private float yBoundary = -5.5f;
    
    void Update()
    {
        if (transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < yBoundary)
        {
            Destroy(gameObject);
        }
    }
}
