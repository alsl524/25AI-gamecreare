using UnityEngine;
using UnityEngine.InputSystem;

public class MoveForceLike : MonoBehaviour
{
    public float speed = 5f;          // 속도 조절
    public float acceleration = 10f;  // 가속도 흉내용
    private Vector2 velocity;         // 현재 속도

    void Update()
    {
        var kb = Keyboard.current;
        float moveX = 0f;
        float moveY = 0f;

        // 방향 입력 감지
        if (kb.upArrowKey.isPressed) moveY += 1f;
        if (kb.downArrowKey.isPressed) moveY -= 1f;
        if (kb.leftArrowKey.isPressed) moveX -= 1f;
        if (kb.rightArrowKey.isPressed) moveX += 1f;

        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        // AddForce()처럼 점점 가속되는 느낌
        velocity += moveDir * acceleration * Time.deltaTime;

        // 속도 제한 (speed)
        velocity = Vector2.ClampMagnitude(velocity, speed);

        // 위치 이동 (Transform 이용)
        transform.position += (Vector3)(velocity * Time.deltaTime);

        // 입력이 없을 때 서서히 감속
        if (moveDir.magnitude == 0)
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, 3f * Time.deltaTime);
        }
    }
}
