using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class tkwn_dbwjzjsxmfhf : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;
    public float JumpPower = 5.0f;

    public GameObject text;

    Animator animator; // ✅ Animator로 변경
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EKd")) // 땅
        {
            Debug.Log("Player : 땅이당");
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }
        if (collision.gameObject.CompareTag("wnrdla")) // 게임 오버 충돌
        {
            Debug.Log("Player : 게임 오버 충돌!");
            text.SetActive(true);
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프!");

            if (animator != null) // ✅ Animator가 있을 때만 실행
            {
                animator.Play("wjavm", -1, 0f);
            }

            rb.linearVelocity = new Vector2(0.0f, JumpPower);
            isJumping = true;
            Debug.Log("Player : isJumping = true");
        }

    }
}
