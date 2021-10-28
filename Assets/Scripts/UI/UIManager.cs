using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;//frena el tiempo en el juego
        optionsPanel.SetActive(true);
    }
    public void AnotherOptions()
    {
        //sound
        //graphics
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();//no va a funcionar hasta que se buildee el juego
    }

}
