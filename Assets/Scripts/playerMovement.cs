using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    //달리기, 점프, 웅크리기 (애니메이션)

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!GameManager.Instance.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GameManager.Instance.isGameActive = true;
            }
        }
        if(GameManager.Instance.isGameActive)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
    }
}
