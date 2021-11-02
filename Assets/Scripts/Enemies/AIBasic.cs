using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public float speed = 0.5f;
    private float waitTime;//tiempo que espera en idle
    public float startWaitTime = 2;

    public Transform[] moveSpots;

    private int i = 0;//hasta donde se va a mover
    private Vector2 actualPos;


    void Start()
    {
        waitTime = startWaitTime;
    }


    void Update()
    {
        StartCoroutine(CheckEnemyMove());
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length-1])
                    i++;
                else
                    i = 0;

                waitTime = startWaitTime;
            }
            else
                waitTime -= Time.deltaTime;
        }
    }
    IEnumerator CheckEnemyMove()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        {
            if (transform.position.x > actualPos.x)
                spriteRenderer.flipX = true;

            else if (transform.position.x < actualPos.x)
                spriteRenderer.flipX = false;

            if (animator.name == "Idle")
            {
                if (transform.position.x == actualPos.x)
                    animator.SetBool("Idle", true);
                else
                    animator.SetBool("Idle", false);
            }
        }
    }
}
