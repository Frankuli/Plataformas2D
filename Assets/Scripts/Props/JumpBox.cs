using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject breakParts;
    public BoxCollider2D col2D;
    public GameObject boxColider;
    public GameObject fruit;
    
    public float jumpForce = 4;
    public int life = 1;

    private void Start()
    {
        fruit.SetActive(false);
        fruit.transform.SetParent(FindObjectOfType<FruitsManager>().transform);//ser hijo de FruitManager

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LoseLIfeAndHit();
        }
    }

    public void LoseLIfeAndHit()
    {
        life--;
        animator.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if (life <= 0)
        {
            fruit.SetActive(true);
            breakParts.SetActive(true);
            boxColider.SetActive(false);
            spriteRenderer.enabled = false;
            col2D.enabled = false;
            Invoke("DestroyBox", 0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);//se destruye el padre
    }
}
