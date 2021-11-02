using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public float jump = 3;
    public float doubleJump = 2.5f;
    public bool canDoubleJump;
    private Rigidbody2D playerRb;

    public bool betterJump;
    public float fallMultiplier = 1;
    public float lowJumpultiplayer = 0.5f;
    
    //las asigno a mano
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public GameObject dustLeft;
    public GameObject dustRight;

    public float dashCooldown;
    public float dashForce = 30;
    public GameObject dashParticle;

    private bool isTouchingFront = false;
    private bool wallSliding; //deslizandose

    public float wallSlidingSpeed = 0.75f;

    private bool isTouchingRight;
    private bool isTouchingLeft;



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        JumpPlayer();
        dashCooldown -= Time.deltaTime;
        WallSliding();


    }

    void FixedUpdate()//por el tema de las fisicas y el movimiento asi es mejor
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !isTouchingRight)
        {
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
            spriteRenderer.flipX = false;//voltea el personaje al caminar
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded)
            {
                dustRight.SetActive(false);
                dustLeft.SetActive(true);
            }

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && !isTouchingLeft)
        {
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded)
            {
                dustRight.SetActive(true);
                dustLeft.SetActive(false);
            }

        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            animator.SetBool("Run", false);
            if (CheckGround.isGrounded)
            {
                dustRight.SetActive(false);
                dustLeft.SetActive(false);
            }
            else
            {
                dustRight.SetActive(false);
                dustLeft.SetActive(false);
            }
        }

        Dash();
    }

    void JumpPlayer()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && CheckGround.isGrounded && !wallSliding)
        {    
            canDoubleJump = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jump);


        }
        else if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) && canDoubleJump)
        {
            animator.SetBool("DoubleJump", true);
            playerRb.velocity = new Vector2(playerRb.velocity.x, doubleJump);
            canDoubleJump = false;
        }

        if (CheckGround.isGrounded) //animacion de salto
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        else
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (playerRb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (playerRb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        if (betterJump)//Salto estilo mario
        {
            if (playerRb.velocity.y < 0)//comprueba si esta bajando
                playerRb.velocity += Vector2.up * Physics2D.gravity * fallMultiplier * Time.deltaTime;//baja mas rapido

            if (playerRb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))//conprueba que sube
                playerRb.velocity += Vector2.up * Physics2D.gravity * lowJumpultiplayer * Time.deltaTime;//baja mas lento
        }
    }

    void WallSliding()
    {
        if (isTouchingFront && !CheckGround.isGrounded)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            animator.Play("WallJump");
            playerRb.velocity = new Vector2(playerRb.velocity.y, Mathf.Clamp(playerRb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    void Dash()
    {
        if (Input.GetKey(KeyCode.V) && dashCooldown <= 0)
        {
            GameObject dashObject;

            dashObject = Instantiate(dashParticle,transform.position, transform.rotation);

            if (spriteRenderer.flipX)
            {
                playerRb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
            }
            else
            {
                playerRb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
            }

            dashCooldown = 2;
            Destroy(dashObject,1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallRight"))
        {
            isTouchingFront = true;
            isTouchingRight = true;
        }
        if (collision.gameObject.CompareTag("WallLeft"))
        {
            isTouchingFront = true;
            isTouchingLeft = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingLeft = false;
        isTouchingRight = false;
    }

}

