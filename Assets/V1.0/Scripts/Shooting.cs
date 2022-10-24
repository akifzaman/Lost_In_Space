using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    public Transform SpawnPosition;
    public AudioClip bulletSound;

    private AudioSource shootingAudio;
    private BulletProperties _bullet;
    public void Initialize(BulletProperties bullet)
    {
        shootingAudio = GetComponent<AudioSource>();
        _bullet = bullet;
        Pool pool = new Pool();
        pool.prefab = _bullet.BulletPrefab;
        pool.tag = _bullet.Tag;
        pool.size = _bullet.NumberSpawn;
        ObjectPooler.Instance.Initialize(pool);
        InvokeRepeating("Fire", 0, _bullet.BulletDelay);
        //StartShooting();
    }

    void Fire()
    {
        if (GameManager.instance.isGameActive)
        {
            GameObject go = ObjectPooler.Instance.SpawnFromPool(_bullet.Tag, SpawnPosition.position, _bullet.BulletPrefab.transform.rotation);
            IPooledObject pooledObj = go.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
                pooledObj.Speed = _bullet.Speed;
                pooledObj.Boundary = _bullet.Boundary;
            }
            shootingAudio.PlayOneShot(bulletSound, 0.04f);
        }
    }

}
