using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsChange : MonoBehaviour
{
    public GameObject panelSkins;
    private bool inDoor = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inDoor = true;
            panelSkins.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inDoor = false;
        panelSkins.gameObject.SetActive(false);
    }

    public void SetPlayerMask()
    {
        PlayerPrefs.SetString("PlayerSelected", "Mask");
        ResetPlayerSkins();
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetPlayerSkins();
    }

    public void SetPlayerPink()
    {
        PlayerPrefs.SetString("PlayerSelected", "Pink");
        ResetPlayerSkins();
    }

    public void SetPlayerVirtual()
    {
        PlayerPrefs.SetString("PlayerSelected", "Virtual");
        ResetPlayerSkins();
    }

    public void ResetPlayerSkins()
    {
        panelSkins.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
