using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticule;
    public float jumpForce = 2.5f;
    public int life = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);//al momento colisionar da un pequeño salto
            LoseLifeAndHit();
            CheckLife();
        }
    }

    public void LoseLifeAndHit()
    {
        life--;
        animator.Play("Hit");
    }

    public void CheckLife()
    {
        if (life == 0)
        {
            destroyParticule.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }

}
