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

    //## Dashing ##//
    [SerializeField]
    private float dashSpeed = 50;
    [SerializeField]
    private float startDashTime;
    private float dashTime;
    private bool dash = false;
    [SerializeField, Tooltip("A partir de cuanto input se toman los valores como verdaderos para la direccion del dash")]
    private float deadValue = 0.3f;
    private Direction dashDirection = Direction.None;

    private Vector2 newVelocity;
    #region  Unity Functions
    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
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
        if (dashDirection == Direction.None)
        {
            if (Input.GetButtonDown("Dash"))
            {
                SetDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            }

        }
        else
        {
            if (dashTime <= 0)
            {
                ResetDash();
            }
            else
            {
                Dash();
            }
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
        if (dashTime != startDashTime) {
            return;
        }
        newVelocity = rigidbody2D.velocity;
        if (isGrounded)
        {
            newVelocity.x = movementInX * controlGrounded * movementSpeed;
            rigidbody2D.velocity = newVelocity;
        }
        else
        {
            newVelocity.x = movementInX * controlInAir * movementSpeed;
            rigidbody2D.velocity = newVelocity;
        }
    }

    private void Dash()
    {
        dashTime -= Time.deltaTime;
        switch (dashDirection)
        {
            case Direction.Up:
                rigidbody2D.velocity = Vector2.up * dashSpeed;
                break;
            case Direction.Down:
                rigidbody2D.velocity = Vector2.down * dashSpeed;
                break;
            case Direction.Left:
                rigidbody2D.velocity = Vector2.left * dashSpeed;
                break;
            case Direction.Right:
                rigidbody2D.velocity = Vector2.right * dashSpeed;
                break;
            case Direction.UpLeft:
                rigidbody2D.velocity = (Vector2.left + Vector2.up) * dashSpeed;
                break;
            case Direction.UpRight:
                rigidbody2D.velocity = (Vector2.right + Vector2.up) * dashSpeed;
                break;
            case Direction.DownLeft:
                rigidbody2D.velocity = (Vector2.left + Vector2.down) * dashSpeed;
                break;
            case Direction.DownRight:
                rigidbody2D.velocity = (Vector2.right + Vector2.down) * dashSpeed;
                break;
        }
    }
    private void SetDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < deadValue && Mathf.Abs(direction.y) >= deadValue)
        { //Up and down
            if (direction.y > 0)
            {
                dashDirection = Direction.Up;
            }
            else
            {
                dashDirection = Direction.Down;
            }
        }
        else if (Mathf.Abs(direction.x) >= deadValue && Mathf.Abs(direction.y) < deadValue)
        {//Left and Right
            if (direction.x > 0)
            {
                dashDirection = Direction.Right;
            }
            else
            {
                dashDirection = Direction.Left;
            }
        }
        else if (Mathf.Abs(direction.x) >= deadValue && Mathf.Abs(direction.y) >= deadValue)
        {
            if (direction.x > 0 && direction.y > 0)
            {
                dashDirection = Direction.UpRight;
            }
            else if (direction.x < 0 && direction.y > 0)
            {
                dashDirection = Direction.UpLeft;
            }
            else if (direction.x > 0 && direction.y < 0)
            {
                dashDirection = Direction.DownRight;
            }
            else if (direction.x < 0 && direction.y < 0)
            {
                dashDirection = Direction.DownLeft;
            }
        }
    }

    private void ResetDash()
    {
        dashTime = startDashTime;
        dashDirection = Direction.None;
        rigidbody2D.velocity = Vector2.zero;
    }


    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight
    }
    #endregion //Private Functions
}