using UnityEngine;
using UnityEngine.InputSystem;

public class Square_Translate : MonoBehaviour
{
    public float Speed = 5f;

    void Update()
    {
        float moveX = 0f, moveY = 0f;
        var kb = Keyboard.current;

        if (kb.leftArrowKey.isPressed) moveX -= 1f;
        if (kb.rightArrowKey.isPressed) moveX += 1f;
        if (kb.upArrowKey.isPressed) moveY += 1f;
        if (kb.downArrowKey.isPressed) moveY -= 1f;

        Vector3 moveDir = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += moveDir * Speed * Time.deltaTime;
    }
}
