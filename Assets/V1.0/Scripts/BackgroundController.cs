using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatHeight;
    [SerializeField] private float movementSpeedMultiplier = 20.0f;

    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider2D>().size.y / movementSpeedMultiplier;
    }

    void Update()
    {
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }

}
