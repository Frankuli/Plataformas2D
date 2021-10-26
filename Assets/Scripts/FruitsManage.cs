using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitsManage : MonoBehaviour
{
    public Text clearLevel;
    public Animator transition;
    private void Update()
    {
        FruitsCollected();// pregunto todo el tiempo por si agarra +1 a la vez
    }
    public void FruitsCollected()
    {
        if (transform.childCount == 0)//Cuenta los hijos de FruitManage
        {
            clearLevel.gameObject.SetActive(true);
            transition.gameObject.SetActive(true);
            Invoke("ChangeScene",1);
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
