using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelClass
{
    
}

[Serializable]
public class BulletProperties
{
    public GameObject BulletPrefab;
    public float BulletDelay;
}

[Serializable]
public class Player
{
    public float speed;
    public float health;
    public int superSplashCounter;
}