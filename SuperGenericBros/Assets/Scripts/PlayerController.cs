using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public float JumpForce = 8f;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private float moveInput;
    private bool isGrounded;
    private bool canDoubleJump;
    private SpriteRenderer playerSprite;
    private Rigidbody2D RB;
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        if (RB == null)
            Debug.LogError("Rigidbody2D saknas");
        if (GroundCheck == null)
            Debug.LogError("Groundcheck saknas");
    }
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.GameState != State.Playing)
        {
            moveInput = 0f;
            return;
        }
        moveInput = Input.GetAxisRaw("Horizontal");
        CheckGround();
        Jump();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        RB.linearVelocity = new Vector2(moveInput * MoveSpeed, RB.linearVelocity.y);
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                RB.linearVelocity = new Vector2(RB.linearVelocity.x, JumpForce);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                RB.linearVelocity = new Vector2(RB.linearVelocity.x, JumpForce);
                canDoubleJump = false;
            }
        }
    }
}