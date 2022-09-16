using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets2 : MonoBehaviour
{
    private float angle = 0f;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("Fire", 0f, 0.1f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
        if (gameManager.miniBossActive)
        {
            
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bullMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bullMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet2();

            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += 10f;
        }
    }
}
