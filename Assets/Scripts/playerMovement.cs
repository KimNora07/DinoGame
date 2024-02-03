using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    //달리기, 점프, 웅크리기 (애니메이션)

    private Animator playerAnimator;
    private Rigidbody2D rb;

    public bool isJumping;

    [SerializeField]
    private float jumpForce = 8.0f;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerAnimator.SetBool("isRun", false);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerAnimator.SetBool("isRun", true);
                GameManager.Instance.isGameActive = true;
            }
        }
        if(GameManager.Instance.isGameActive == true)
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerAnimator.SetBool("isRun", false);
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerAnimator.SetBool("isRun", false);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance.isGameActive == true && isGrounded == true)
        {
            playerAnimator.SetBool("isRun", true);
        }
    }
}
