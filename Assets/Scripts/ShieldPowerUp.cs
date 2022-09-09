using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public bool isShieldActivated;
    public GameObject shieldPowerUp;
    public Transform shieldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerController.isShieldActivated = true;
            Destroy(gameObject);
            isShieldActivated = true;
            if (isShieldActivated)
            {
                shieldPowerUp.SetActive(true);
            }
        }
    }

}