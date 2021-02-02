using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementTest : MonoBehaviour
{
    [SerializeField]
    private InputSchema control;
    [SerializeField]
    private GameStatus status;
    
    public GameObject otherPlayer;
    
    private GameObject otherMeow;

    [SerializeField]
    private string tagFish;
    [SerializeField]
    private string tagFishUI;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int fish;
    [SerializeField]
    private AudioSource meowAudio;

    private bool isGrounded;
    private bool jumped;
    private bool meowed;
    private float dir;
    private Rigidbody2D rb;

    private Vector2 meowDir;

    public Vector2 position;

    private Animator animator;

    private SpriteRenderer sprite;


    public Sprite meowRight;
    public Sprite meowLeft;

    private ManagerCanvas canvas;



    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        jumped = false;

        rb = GetComponent<Rigidbody2D>();

       status.fish[fish] = 0;

       canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ManagerCanvas>();



       switch (fish)
       {
            case 0:
                   
                    otherMeow = canvas.meows[fish];
                break;
            case 1:  
                  
                    otherMeow = canvas.meows[fish];
                break;
       }


       animator = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputsUpdate();
    }

    private void InputsUpdate()
    {
        Animations();

        Move();
        Meow();
        Jump();
    }

    private void Animations()
    {
         
        if(dir < 0)
        {
            sprite.flipX = true;
        }
        else if(dir > 0)
        {
            sprite.flipX = false;
        }

        if(control.IsJumping() && isGrounded)
        {
            animator.SetTrigger("Jump");
        }

        if(control.IsMeowning() && isGrounded)
        {
            animator.SetTrigger("Meow");
        }

        
        if(dir > 0 || dir < 0 )
        {
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk",false);
        }

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

                otherMeow.GetComponent<Image>().color = Color.white;


                if(meowDir.x < 0)
                {
                    otherMeow.GetComponent<Image>().sprite = meowLeft;
                }
                else
                {
                    otherMeow.GetComponent<Image>().sprite = meowRight;
                }

                

                if(fish == 1)
                {
                    otherMeow.transform.localPosition = meowDir*200;
                    otherMeow.transform.localPosition = meowDir*180;
                }
                else
                {
                    otherMeow.transform.localPosition = (new Vector3(meowDir.x*-1,meowDir.y,0)*200);
                    otherMeow.transform.localPosition = (new Vector3(meowDir.x*-1,meowDir.y,0)*180);
                }

                if(position == otherPlayer.GetComponent<MovementTest>().position)
                {
                    if(fish == 1)
                    {
                        if(status.fish[0]>=5)
                        {
                            SceneManager.LoadScene(2);
                        }
                    }
                    else
                    {
                        if(status.fish[1]>=5)
                        {
                            SceneManager.LoadScene(2);
                        }
                    }  
                    
                }

                StartCoroutine(DownMeow());
            }

            meowAudio.Play();
        }
    }

    IEnumerator DownMeow()
    {
    
        yield return new WaitForSeconds(0.6f);
        
       otherMeow.GetComponent<Image>().color = new Color(0,0,0,0);
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
            canvas.AtualizeUI(fish);

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


    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


}