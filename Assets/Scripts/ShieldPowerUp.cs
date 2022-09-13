using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public bool isShieldActivated;
    public GameObject shieldPowerUp;
    public Transform shieldPosition;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.ActivateShield();
            //isShieldActivated = true;
            //if (isShieldActivated)
            //{
            //    shieldPowerUp.SetActive(true);
            //}

        }
    }

}