using UnityEngine;

public class TriangleMove : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // speed�� �̿��� �������� �̵�
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player �±� ���� ������Ʈ�� �浹�ϸ�
        {
            Time.timeScale = 0f; // ���� �ð� ����
            Debug.Log("Player hit spike! Game Paused.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tkrwprl"))
        {
            Destroy(gameObject); // �ﰢ�� ����
            Debug.Log("Spike : �Ҹ�");
        }
    }
}
