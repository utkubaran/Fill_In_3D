using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    [Space]
    [SerializeField]
    Joystick joystick;

    [Space]
    [SerializeField]
    float speed = 10f;

    Rigidbody rb;
    Vector3 direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(joystick.Direction.magnitude >= 0.5f)
        {
            direction = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
            rb.velocity = direction * speed;

            Rotate();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }

    void Rotate()
    {
        if (direction.magnitude >= 0.5f)
        {
            rb.freezeRotation = false;
            rb.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            rb.freezeRotation = true;
        }
    }
}
