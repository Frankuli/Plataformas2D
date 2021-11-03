using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2D : MonoBehaviour
{
    public SpriteRenderer swordSprite;
    public BoxCollider2D swordColl;
    public Animator animator;
    public GameObject swordParent;

    private SpriteRenderer playerSpriteRenderer;



    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack(); 
        }

        if (playerSpriteRenderer.flipX)
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Attack()
    {
        swordSprite.enabled = true;
        swordColl.enabled = true;
        animator.Play("Attack");
        Invoke("DisableSword",0.5f);

    }

    private void DisableSword()
    {
        swordSprite.enabled = false;
        swordColl.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LoseLifeAndHit();
            swordSprite.enabled = false;
            swordColl.enabled = false;

        }
    }
}
