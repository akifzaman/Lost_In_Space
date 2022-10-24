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
    public int NumberSpawn;
    public string Tag;
    public float BulletDelay;
    public float Speed;
    public float Boundary;
    public GameObject BulletPrefab;
}

[Serializable]
public class Player
{
    public float speed;
    public float health;
    public int superSplashCounter;
}


[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}