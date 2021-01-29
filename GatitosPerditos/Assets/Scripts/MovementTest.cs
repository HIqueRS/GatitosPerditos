using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField]
    private InputSchema control;
    private float dir;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    private bool isGrounded;
    private bool jumped;
    private bool meowed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        jumped = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputsUpdate();
    }

    private void InputsUpdate()
    {
        Jump();
        Move();
        Meow();
    }

    private void Meow()
    {
        meowed = control.IsMeowning();

    }

    private void Move()
    {
        dir = Input.GetAxis(control.axis);

        transform.position += new Vector3(dir * Time.deltaTime * speed, 0, 0);
    }

    private void Jump()
    {
        jumped = control.IsJumping();

        if (jumped)
        {

            if(isGrounded)
            {
                rb.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse) ;
                isGrounded = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}
