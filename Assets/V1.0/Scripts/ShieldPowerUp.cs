using System.Collections;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject shieldPowerUp;
    public Transform shieldPosition;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(ShieldPowerUpDestroy());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.ActivateShield();

        }
    }
    IEnumerator ShieldPowerUpDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}