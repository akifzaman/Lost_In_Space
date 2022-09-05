using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;

    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    public void Fire()
    {
        Instantiate(bullet,bullet.transform.position, Quaternion.identity);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        Fire();
    }
}
