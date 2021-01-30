using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{


    private bool jump;
    private bool isJumping = false;

    Rigidbody2D rigidbody2D;
    [SerializeField]
    private float jumpForce = 5f;

    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        if (jump && isJumping == false)
        {
            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ResetIsJumping();
        }
    }

    private void Jump()
    {
        if (isJumping)
        {
            return;
        }
        isJumping = true;
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    private void ResetIsJumping()
    {
        isJumping = false;
    }
}
