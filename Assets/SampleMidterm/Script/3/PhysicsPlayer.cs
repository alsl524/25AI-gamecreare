using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Physics_Tag : MonoBehaviour
{
    [Header("이동 관련 설정")]
    public float moveAccel = 30f;      // 가속도
    public float maxMoveSpeed = 5f;    // 최대 속도

    [Header("점프 관련 설정")]
    public float jumpPower = 10f;      // 점프 초기 속도
    public float gravityScale = 1.5f;  // 중력 크기

    [Header("Ground 판정용")]
    public string groundTag = "Ground";  // 바닥 태그 이름

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool wantJump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        // --- 이동 ---
        float moveX = 0f;
        if (kb.leftArrowKey.isPressed) moveX -= 1f;
        if (kb.rightArrowKey.isPressed) moveX += 1f;

        // 속도 제한 + 부드러운 가속
        Vector2 velocity = rb.linearVelocity;
        velocity.x = Mathf.MoveTowards(velocity.x, moveX * maxMoveSpeed, moveAccel * Time.deltaTime);
        rb.linearVelocity = new Vector2(velocity.x, velocity.y);

        // --- 점프 입력 ---
        if (kb.spaceKey.wasPressedThisFrame && isGrounded)
        {
            wantJump = true;
        }
    }

    void FixedUpdate()
    {
        if (wantJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            wantJump = false;
            Debug.Log("Jump!");
        }
    }

    // --- 충돌 처리 ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥 감지
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = true;
            Debug.Log("Grounded!");
        }

        // 빨간 벽 감지
        if (collision.gameObject.CompareTag("RedWall"))
        {
            Debug.Log("Player: 빨강아야 (Collision)");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = false;
            Debug.Log("Leave ground");
        }
    }

    // 트리거(녹색 벽)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenWall"))
        {
            Debug.Log("Player: 초록아야 (Trigger)");
        }
    }
}
