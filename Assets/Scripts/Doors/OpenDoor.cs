using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true;
            text.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inDoor = false;
        text.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (inDoor && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
