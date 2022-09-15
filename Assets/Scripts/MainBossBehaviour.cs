using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainBossBehaviour : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    private PlayerHealthBar _playerHealthBar;

    public bool moveDown = true;
    public bool parry = false;
    public bool parryAllow = true;
    public GameManager gameManager;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthBar>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(ParryRestore());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(transform.position.y - playerController.transform.position.y)););
        if (gameManager.miniBossDestroyed && gameManager.isGameActive)
        {
            if (transform.position.y > 4.0f)
            {
                moveDown = true;
            }
            else if (transform.position.y < -4.0f)
            {
                moveDown = false;
            }

            if (moveDown)
            {
                transform.position =
                    new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position =
                    new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            }
        }

        if (gameManager.miniBossDestroyed && gameManager.isGameActive)
        {
            if (Mathf.Abs(transform.position.y - playerController.transform.position.y) <= 1.75f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && parryAllow)
                {
                    playerController.ActivateParryShield();
                    Debug.Log("well done!");
                    parry = true;
                    parryAllow = false;
                }
            }
            else if(Input.GetKeyDown(KeyCode.Space) && parryAllow && !parry)
            {
                parryAllow = false;
                StartCoroutine(ParryRestore());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!parry)
            {
                _playerHealthBar.DamageTaken(5);
                parryAllow = true;
            }
            else if (!parryAllow && parry)
            {
                _playerHealthBar.DamageTaken(-2);
                parry = false;
                //parryAllow = false;
                StartCoroutine(ParryRestore());
            }
        }
    }
    IEnumerator ParryRestore()
    {
        yield return new WaitForSeconds(0.05f);
        if (gameManager.isGameActive)
        {
            parryAllow = true;
        }
    }
}
