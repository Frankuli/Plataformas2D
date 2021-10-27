using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer;

    public enum Player {Mask, Frog, Pink, Virtual};//seleccion
    public Player playerSelected;
    
    //referencias 
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;//arboles de animaciones
    public Sprite[] playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (!enableSelectPlayer)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Mask:
                    animator.runtimeAnimatorController = playerController[0];
                    spriteRenderer.sprite = playerRenderer[0];
                    break;

                case Player.Frog:
                    animator.runtimeAnimatorController = playerController[1];
                    spriteRenderer.sprite = playerRenderer[1];
                    break;

                case Player.Pink:
                    animator.runtimeAnimatorController = playerController[2];
                    spriteRenderer.sprite = playerRenderer[2];
                    break;

                case Player.Virtual:
                    animator.runtimeAnimatorController = playerController[3];
                    spriteRenderer.sprite = playerRenderer[3];
                    break;

                default:
                    break;
            }
        }


    }
    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Mask":
                animator.runtimeAnimatorController = playerController[0];
                spriteRenderer.sprite = playerRenderer[0];
                break;

            case "Frog":
                animator.runtimeAnimatorController = playerController[1];
                spriteRenderer.sprite = playerRenderer[1];
                break;

            case "Pink":
                animator.runtimeAnimatorController = playerController[2];
                spriteRenderer.sprite = playerRenderer[2];
                break;

            case "Virtual":
                animator.runtimeAnimatorController = playerController[3];
                spriteRenderer.sprite = playerRenderer[3];
                break;

            default:
                break;
        }
    }
}
