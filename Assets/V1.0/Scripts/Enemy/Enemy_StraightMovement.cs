using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StraightMovement : Enemy
{
    public override void OnObjectSpawn()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
        StartCoroutine(shooting.Fire(bulletProperties));
    }
    private void OnEnable()
    {
        shooting = GetComponent<Shooting>();
        shooting.CanShoot = !GameManager.instance.OnSpeedUp;
    }
}
