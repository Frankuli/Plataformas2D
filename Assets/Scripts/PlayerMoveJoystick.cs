using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0;
    public Joystick joystick;

    public float runSpeedHorizontal = 2;
    public float speed = 1.25f;
    public float jump = 3;
    public float doubleJump = 2.5f;
    public bool canDoubleJump;
    private Rigidbody2D playerRb;

    //las asigno a mano
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        JumpPlayer();
        
    }

    void FixedUpdate()//por el tema de las fisicas y el movimiento asi es mejor
    {
        MovePlayer();
        Move();

    }

    void MovePlayer()
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;//voltea el personaje al caminar
            animator.SetBool("Run", true);
        }

        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    void JumpPlayer()
    {
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
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jump);

        }
        else if (canDoubleJump)
        {
            animator.SetBool("DoubleJump", true);
            playerRb.velocity = new Vector2(playerRb.velocity.x, doubleJump);
            canDoubleJump = false;
        }
    }

    public void Move()
    {
       
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed ;
    }

}
