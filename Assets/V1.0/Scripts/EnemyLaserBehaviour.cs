using UnityEngine;

public class EnemyLaserBehaviour : MonoBehaviour
{
    private PlayerHealthBar _playerHealthBar;
    
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("EnemyLaser") && other.gameObject.CompareTag("Player"))
        {
            _playerHealthBar.DamageTaken(3.5f);
        }
    }
}
