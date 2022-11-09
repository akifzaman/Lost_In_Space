using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    public float speed, amount, duration;

    private Vector3 startPos, shakePos;

    void Start()
    {
        //MiniBoss = GameObject.Find("MiniBoss").GetComponent<MiniBossActivate>();
        shakePos = startPos = transform.position;
        speed = 2.34f;
        amount = 0.06f;
        duration = 5.0f;
    }

    void Update()
    {
        if (duration > 0 && GameManager.instance.timeCounter < -40 && GameManager.instance.miniBossActive == false)
        {
            Shake();
            duration -= Time.deltaTime;
        }
        else if (duration > 0 && GameManager.instance.timeCounter < -5)
        {
            Shake();
            duration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * Mathf.Abs(speed));
        }
    }

    void Shake()
    {
        if (transform.position == shakePos)
        {
            shakePos = startPos + new Vector3(Random.Range(-amount, amount), Random.Range(-amount, amount), 0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, shakePos, Time.deltaTime * Mathf.Abs(speed));
        }
    }
}
