using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{


    private bool jump = false;
    [SerializeField]
    private bool isGrounded = true;


    Rigidbody2D rigidbody2D;
    [Header("Movement Control")]
    [SerializeField]
    private float movementSpeed = 3f;
    [SerializeField]
    private float controlInAir = 0.7f;
    [SerializeField]
    private float controlGrounded = 1f;
    [SerializeField]
    private float jumpForce = 5f;

    private Vector2 newVelocity;
    #region  Unity Functions
    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

    }
    private void FixedUpdate()
    {
        if (jump && isGrounded == true)
        {
            Jump();
        }
        Move(Input.GetAxis("Horizontal"));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ResetGrounded();
        }
    }
    #endregion //Unity Functions


    #region Private Functions 
    private void Jump()
    {
        if (isGrounded == false)
        {
            return;
        }
        isGrounded = false;
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    private void ResetGrounded()
    {
        isGrounded = true;
    }

    private void Move(float movementInX)
    {
        newVelocity = rigidbody2D.velocity;
        if (isGrounded)
        {
            newVelocity.x = movementInX * controlGrounded * movementSpeed;
            rigidbody2D.velocity = newVelocity;
        }
        else {
            newVelocity.x = movementInX * controlInAir * movementSpeed;
            rigidbody2D.velocity = newVelocity;
        }
    }
    #endregion //Private Functions
}
