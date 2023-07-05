using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract PlayerController Player { get; set; }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    public abstract void UsePowerUp();
    public virtual void OnCollisionEnter2D(Collision2D other)
    {
	    Player = other.gameObject.GetComponent<PlayerController>();
		AudioSource.PlayClipAtPoint(Player.powerUpSound, Camera.main.transform.position, 1.0f);
		UsePowerUp();
        gameObject.SetActive(false);
    }
}
