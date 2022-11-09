using UnityEngine;

public class FireBullets : MonoBehaviour
{

    [SerializeField] private int bulletsAmount = 20;
    [SerializeField] private float startAngle = 90f, endAngle = 440f;

    void Start()
    {
        InvokeRepeating("Fire", 0f, 1f);
    }

    private void Fire()
    {
        if (GameManager.instance.miniBossActive)
        {
            float angleStep = (endAngle - startAngle) / bulletsAmount;
            float angle = startAngle;

            for (int i = 0; i < bulletsAmount; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bullMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bullMoveVector - transform.position).normalized;

                //GameObject bul = BulletPool.bulletPoolInstance.GetBullet1();
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet1();

                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }
    }
}
