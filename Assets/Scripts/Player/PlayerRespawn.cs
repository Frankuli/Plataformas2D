using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;

    public GameObject[] heart;
    private int life;
    void Start()
    {
        life = heart.Length;
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0) {

            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
        
    }
    public void ReachedChecPoint(float x, float y)
    {
        //mantiene la informacion 
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamage()
    {
        life--;
        CheckLife();
    }

    void CheckLife()
    {
        animator.Play("Hit");
        if (life < 1)
        {
            Destroy(heart[0].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life < 2)
        {
            Destroy(heart[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(heart[2].gameObject);
        }
    }
}
