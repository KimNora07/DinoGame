using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    //달리기, 점프, 웅크리기 (애니메이션)

    private Animator playerAnimator;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public bool isJumping;
    public bool isShifting;

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
        bc = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        playerAnimator.SetBool("isStand", true);
        playerAnimator.SetBool("isRun", false);
        playerAnimator.SetBool("isShift", false);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerAnimator.SetBool("isRun", true);
                playerAnimator.SetBool("isStand", false);
                GameManager.Instance.isGameActive = true;
            }
        }
        if(GameManager.Instance.isGameActive == true)
        {
            if(isGrounded == true)
            {
                playerAnimator.SetBool("isRun", true);
                playerAnimator.SetBool("isStand", false);
            }
            Jump();
            Shift();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true && isShifting == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerAnimator.SetBool("isRun", false);
            playerAnimator.SetBool("isStand", true);
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump") && isJumping == true && isShifting == false)
        {
            if (jumpTimeCounter > 0)
            {
                playerAnimator.SetBool("isRun", false);
                playerAnimator.SetBool("isStand", true);
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

    private void Shift()
    {
        if (Input.GetButtonDown("Shift") && isGrounded == true && isJumping == false)
        {
            playerAnimator.SetBool("isShift", true);
            playerAnimator.SetBool("isRun", false);
            playerAnimator.SetBool("isStand", false);
            bc.size = new Vector2(0.875f, 0.46875f);
            isShifting = true;
        }

        if (Input.GetButton("Shift"))
        {
            if (isGrounded == true)
            {
                playerAnimator.SetBool("isShift", true);
                playerAnimator.SetBool("isRun", false);
                playerAnimator.SetBool("isStand", false);
                rb.gravityScale = 7f;
            }
            else
            {
                rb.gravityScale = 15f;
            }
            bc.size = new Vector2(0.875f, 0.46875f);
            isShifting = true;
        }

        if (Input.GetButtonUp("Shift"))
        {
            if(isGrounded == true)
            {
                playerAnimator.SetBool("isShift", false);
                playerAnimator.SetBool("isRun", true);
                playerAnimator.SetBool("isStand", false);
            }
            else
            {
                playerAnimator.SetBool("isShift", false);
                playerAnimator.SetBool("isRun", false);
                playerAnimator.SetBool("isStand", true);
            }
            bc.size = new Vector2(0.63f, 0.7f);
            rb.gravityScale = 7f;
            isShifting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            GameManager.Instance.isDie = true;
        }
    }
}
