using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementTest : MonoBehaviour
{
    [SerializeField]
    private InputSchema control;
    [SerializeField]
    private GameStatus status;
    [SerializeField]
    private GameObject otherPlayer;
    [SerializeField]
    private Image otherMeow;

    [SerializeField]
    private Image[] fishes;

    [SerializeField]
    private string tagFish;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int fish;

    private bool isGrounded;
    private bool jumped;
    private bool meowed;
    private float dir;
    private Rigidbody2D rb;

    private Vector2 meowDir;

    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        jumped = false;

        rb = GetComponent<Rigidbody2D>();

       status.fish[fish] = 0;
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

        if(meowed)
        {
            if(status.fish[fish] >= 5)
            {
                meowDir = transform.position - otherPlayer.transform.position;
                meowDir = meowDir.normalized;

                otherMeow.color = Color.white;

                

                if(fish == 1)
                {
                    otherMeow.transform.localPosition = meowDir*100;
                }
                else
                {
                    otherMeow.transform.localPosition = (new Vector3(meowDir.x*-1,meowDir.y,0)*100);
                }

                StartCoroutine(DownMeow());
            }
        }
    }

    IEnumerator DownMeow()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.6f);
        
        otherMeow.color = new Color(0,0,0,0);
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
                rb.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
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
        else if(collision.gameObject.CompareTag(tagFish))
        {
            status.fish[fish]+=1;

            fishes[status.fish[fish]-1].color = Color.white;

            GameObject.Destroy(collision.gameObject);

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
