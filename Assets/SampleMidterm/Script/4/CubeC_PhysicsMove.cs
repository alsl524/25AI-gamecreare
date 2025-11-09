using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CubeC_PhysicsMove : MonoBehaviour
{
    public float Speed = 2f;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
    {
        // physics 속도 설정 (linearVelocity 권장)
        Vector2 v = rb.linearVelocity;
        v.x = Speed; // 오른쪽으로 일정 속도
        rb.linearVelocity = v;
    }
}
