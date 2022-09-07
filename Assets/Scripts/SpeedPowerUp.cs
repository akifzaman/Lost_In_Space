using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private MoveDown moveDownController;
    // Start is called before the first frame update
    void Start()
    {
        moveDownController = GameObject.Find("Background").GetComponent<MoveDown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("power up!");
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            moveDownController.speed *= 10;
        }
    }
}
