using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    float Speed { get; set; }
    float Boundary { get; set; }
    void OnObjectSpawn();
}
