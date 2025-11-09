using UnityEngine;

public class BallBounceAuto : MonoBehaviour
{
    [Header("설정")]
    public float bounceForce = 7f;     // 튀어오르는 힘
    public float groundCheckDelay = 0.2f; // 연속 충돌 방지용 딜레이
    public string groundTag = "Ground";   // 바닥 태그 이름

    private Rigidbody2D rb;
    private Animator anim;
    private bool canBounce = true; // 연속 중복 방지용

    private Vector3 startPos; // 초기 위치 기억 (튀어오를 최대 높이용)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) && canBounce)
        {
            // 🔸 애니메이션 재생
            anim.SetTrigger("Bounce");

            // 🔸 점프 처리
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

            // 🔸 연속 충돌 방지
            canBounce = false;
            Invoke(nameof(ResetBounce), groundCheckDelay);
        }
    }

    void ResetBounce()
    {
        canBounce = true;
    }

    void Update()
    {
        // 🔹 공이 너무 위로 안 올라가면, 시작 높이까지 튀어오르게 유지
        if (transform.position.y > startPos.y)
        {
            // 너무 위로 올라가면 감속
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Min(rb.linearVelocity.y, 0));
        }
    }
}
