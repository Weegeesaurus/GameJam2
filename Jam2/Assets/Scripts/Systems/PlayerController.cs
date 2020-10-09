using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public CharacterController controller;
    private float yVelocity = 0;
    public float jumpSpeed = 5;
    public float gravity = 9.81f;

    // Start is called before the first frame update
    void Start()
    {
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        moveSpeed *= Time.fixedDeltaTime;
        jumpSpeed *= Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 _moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
        _moveDirection *= moveSpeed;

        if (controller.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetButton("Jump"))
            {
                yVelocity = jumpSpeed;
            }

        }
        yVelocity -= gravity;

        _moveDirection.y = yVelocity;
        controller.Move(_moveDirection);
    }
}
