using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject beeBullet;

    public float distanceRaycast = 0.5f;

    public float cooldownAttack = 1.5f;
    private float currentCooldownAttack;

    private void Start()
    {
        currentCooldownAttack = 0;
    }

    private void Update()
    {
        currentCooldownAttack -= Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if (hit2D.collider != null && hit2D.collider.CompareTag("Player") && currentCooldownAttack < 0)
        {
            Invoke("LaunchBullet", 0.5f);
            animator.Play("Attack");
            currentCooldownAttack = cooldownAttack;

        }
    }
    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
