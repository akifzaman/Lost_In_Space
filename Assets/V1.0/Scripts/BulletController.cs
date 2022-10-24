using UnityEngine;

public class BulletController : MonoBehaviour, IPooledObject
{
    public float Speed { get; set; }
    public float Boundary { get; set; }

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
        if (transform.position.y > Boundary)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnObjectSpawn()
    {
        
    }
}
