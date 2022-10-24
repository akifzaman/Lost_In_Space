using System.Collections;
using UnityEngine;



public class Enemy_FollowPlayer : Enemy
{
    public GameObject laserObject;
    public bool laserActivate = false;

    public GameObject enemyExplosion;
    public GameObject laserReload;
    //public GameObject EnemyBullet;
    public AudioClip explosionSound;
    
    public AudioClip enemyLaserSound;
    public AudioClip enemyLaserLoadSound;

    [SerializeField] private float rotateAngle = 1.0f;
    [SerializeField] private bool lookDirectionAllow;
   

    private GameObject player;
    
    private PlayerHealthBar _playerHealthBar;

    public void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        /*if (enemyType == EnemyType.FollowPlayer)
        {
            transform.Rotate(0.0f, 0.0f * Time.deltaTime, rotateAngle, 0.0f);

            if (lookDirectionAllow && GameManager.instance.isGameActive)
            {
                if (transform.position.y > player.transform.position.y)
                {
                    Vector2 lookDirection = (player.transform.position - transform.position).normalized;
                    transform.Translate(lookDirection * Time.deltaTime * speed, Space.World);

                }
                else
                {
                    lookDirectionAllow = false;
                }
            }
        }
        
        else if (GameManager.instance.isGameActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }*/

        
    }

    //TODO- need to refactor
    IEnumerator Laser()
    {
        yield return new WaitForSeconds(3.0f);
        if (GameManager.instance.miniBossActive)
        {
            GameObject bossLaserReload = Instantiate(laserReload,  transform);
            AudioSource.PlayClipAtPoint(enemyLaserLoadSound, Camera.main.transform.position, 1.0f);
            Destroy(bossLaserReload, 1.0f);
            yield return new WaitForSeconds(1.0f);
            AudioSource.PlayClipAtPoint(enemyLaserSound, Camera.main.transform.position, 1.0f);
        }

        if (laserActivate)
        {
            laserObject.SetActive(true);
        }

        yield return new WaitForSeconds(1.0f);
        if (laserActivate)
        {
            laserObject.SetActive(false);
        }

        StartCoroutine(Laser());
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("bullet_lvl1") || other.gameObject.CompareTag("bullet_lvl2"))
        {
            enemy.health--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
            if (enemy.health <= 0)
            {
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
                Destroy(explosion, 0.5f);
                GameManager.instance.score++;
                Destroy(gameObject);
            }
        }
        //TODO - Add in Player
        /*else if (gameObject.CompareTag("MiniBoss") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.UpdateSlider(20);
            Destroy(other.gameObject);
        }#1#
        
        else if (gameObject.CompareTag("MiniBoss") && other.gameObject.CompareTag("bullet_lvl1"))
        {
            enemy.health--;
            AudioSource.PlayClipAtPoint(enemyHitSound, Camera.main.transform.position, 0.1f);
     //       _enemyHealthBar.UpdateSlider(1);
            if (enemy.health <= 0)
            {
                //TODO - Add in Player
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position, 1.0f);
                GameManager.instance.miniBossActive = false;
                GameManager.instance.miniBossDestroyed = true;
                Destroy(explosion, 0.5f);
                GameManager.instance.score += 100;
                Destroy(gameObject);
            }
        }

    }*/

}
