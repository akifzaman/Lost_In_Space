using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatHeight;
    [SerializeField] private float movementSpeedMultiplier = 2.10f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider2D>().size.y * movementSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }
}
