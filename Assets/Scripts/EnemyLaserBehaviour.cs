using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserBehaviour : MonoBehaviour
{
    private PlayerHealthBar _playerHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("EnemyLaser") && other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hello");
            _playerHealthBar.DamageTaken(3.5f);
        }
    }
}
