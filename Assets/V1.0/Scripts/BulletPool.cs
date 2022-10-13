using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField] private GameObject pooledBullet1;
    [SerializeField] private GameObject pooledBullet2;
    private bool notEnoughBulletInPool = true;

    private List<GameObject> bullets;

    public MiniBossActivate MiniBoss;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        bulletPoolInstance = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBullet1()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletInPool)
        {
            GameObject bul = Instantiate(pooledBullet1);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
    public GameObject GetBullet2()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletInPool)
        {
            GameObject bul = Instantiate(pooledBullet2);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
