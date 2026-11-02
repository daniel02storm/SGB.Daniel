using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public float JumpForce = 8f;
    private float moveInput;
    private SpriteRenderer playerSprite;
    private Rigidbody2D RB;
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        if (RB == null)
            Debug.LogError("Rigidbody2D saknas");
    }
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.GameState != StateMachineBehaviour.Playing)
        {
            moveInput = 0f;
            return;
        }
        moveInput = Input.GetAxisRaw("Horizontal");
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
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {

}