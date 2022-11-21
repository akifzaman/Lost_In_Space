using UnityEngine;

public class BulletController : MonoBehaviour, IPooledObject
{
    public float Speed { get; set; }
    public float Boundary { get; set; }

    public float DamageAmount = 1.0f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }
    public void OnObjectSpawn()
    {
       
    }
}
