using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Vector3 startPos;
    Vector3 deltaPos;
    Vector3 direction;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - startPos;

            direction = new Vector3(deltaPos.x, 0f, deltaPos.y);
            direction = direction.normalized * speed;

            rb.velocity = direction;

            Rotate();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Rotate()
    {
        if (direction.magnitude >= 0.05f)
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
