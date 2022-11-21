using UnityEngine;

public class Enemy_FollowPlayer : Enemy, IPooledObject
{
    [SerializeField] private bool lookDirectionAllow;
    private Vector2 lookDirection;
    private Transform lookTransform;

    void Start()
    {
        lookDirection = lookDirectionAllow ? (lookTransform.position - transform.position) : Vector2.down;
    }
    public void Update()
    {
        if (!GameManager.instance.isGameActive) return;
        DirectionalMovement();
    }
    private void OnEnable()
    {
        shooting = GetComponent<Shooting>();
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
    }
    public override void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        lookTransform = GameManager.instance.playerController.gameObject.transform;
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;

        StartCoroutine(shooting.Fire(bulletProperties));
    }
    
    private void DirectionalMovement()
    {
        lookDirectionAllow = (transform.position.y > lookTransform.position.y);
        lookDirection = lookDirectionAllow ? (lookTransform.position - transform.position) : (Vector2.down * 2);
        transform.Translate(lookDirection * Time.deltaTime * enemyProperties.Speed, Space.World);
    }
}
