using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);//Animacion de desaparecer

            Destroy(gameObject, 0.5f);
        }
    }
}
