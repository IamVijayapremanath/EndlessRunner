using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float forward_speed = 5f;
    public float side_speed = 5f;
    public float jump_force = 5f;

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
    }
}
