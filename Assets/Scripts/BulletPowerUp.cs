using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour
{
    //public Shooting shootingController;
    //public GameManager gameManager;
    public Shooting shooting;
    public DoubleShooting doubleShooting;
   
    // Start is called before the first frame update
    void Start()
    {
        //shootingController = GameObject.Find("Player").GetComponent<Shooting>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
        doubleShooting = GameObject.Find("Player").GetComponent<DoubleShooting>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("bullet up!");
        if (other.gameObject.CompareTag("Player"))
        {
           // gameManager.doubleBulletActivate = true;
           doubleShooting.isActivatedTwo = true;
           shooting.isActivatedOne = false;
           Destroy(gameObject);
        }
    }
}
