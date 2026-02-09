using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float forward_speed = 5f;
    public float side_speed = 5f;
    public GameUI gameUI;

    public float Range = 4.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * forward_speed * Time.deltaTime);

        if(Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector3.left * side_speed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * side_speed * Time.deltaTime);
        }

        float clampedX = Mathf.Clamp(transform.position.x, -Range, Range);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (gameUI != null)
            {
                gameUI.DecreaseLife();
            }
            Destroy(other.gameObject);
        }
    }

}
