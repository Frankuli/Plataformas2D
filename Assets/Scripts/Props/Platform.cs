using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))//cuando levanta el dedo de la tecla
        {
            waitTime = startTime;//reinicia
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)//tarda un ratito
            {
                effector.rotationalOffset = 180;//giro
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))//cuando salta 
        {
            effector.rotationalOffset = 0; //reinicio la plataforma
        }
    }
}
