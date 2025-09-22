using UnityEngine;

public class TriangleMove : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // speed를 이용해 왼쪽으로 이동
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player 태그 가진 오브젝트와 충돌하면
        {
            Time.timeScale = 0f; // 게임 시간 멈춤
            Debug.Log("Player hit spike! Game Paused.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tkrwprl"))
        {
            Destroy(gameObject); // 삼각형 제거
            Debug.Log("Spike : 소멸");
        }
    }
}
