using System;
using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public abstract PlayerController Player { get; set; }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    public abstract void UsePowerUp();
    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.gameObject.GetComponent<PlayerController>();
            UsePowerUp();
            gameObject.SetActive(false);
        }
    }
}
