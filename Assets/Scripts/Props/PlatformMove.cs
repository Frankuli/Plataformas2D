using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{


    public float speed = 0.5f;
    private float waitTime;//tiempo que espera en idle
    public float startWaitTime = 2;

    public Transform[] moveSpots;

    private int i = 0;//hasta donde se va a mover




    void Start()
    {
        waitTime = startWaitTime;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                    i++;
                else
                    i = 0;

                waitTime = startWaitTime;
            }
            else
                waitTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
