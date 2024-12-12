using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private bool jumpPressed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;            
        }
    }
    private void FixedUpdate()
    {
        ApplyJumpForce();
    }
    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);  // reiniciar "y" para superar la fuerza de gravedad
            rb.AddForce(transform.up * jumpForce);
            jumpPressed = false;
        }
    }
}
