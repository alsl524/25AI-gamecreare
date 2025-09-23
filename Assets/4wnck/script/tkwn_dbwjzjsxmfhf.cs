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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = true ;
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("EKd"))
        {
            Debug.Log("Player : 땅이당");
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }
        if (collision.gameObject.CompareTag("wnrdla"))
        {
            Debug.Log("Player : 게임 오버 충돌!");
            text.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프!");
            animator.Play("wjavm", -1, 0f); // ✅ Animator State 실행
            rb.linearVelocity = new Vector2(0.0f, JumpPower);
            isJumping = true;
            Debug.Log("Player : isJumping = true");
        }
    }

}