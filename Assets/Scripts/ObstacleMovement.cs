using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 2f;

    private float start;
    private bool movingRight = true;

    void Start()
    {
        start = transform.position.x;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= start + distance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= start - distance)
                movingRight = true;
        }
    }
}
