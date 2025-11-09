using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Triangle_SetVelocity : MonoBehaviour
{
    public float Speed = 5f;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        var kb = Keyboard.current;
        float moveX = 0f, moveY = 0f;

        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) moveX -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) moveX += 1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) moveY += 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) moveY -= 1f;

        Vector2 move = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = move * Speed;
    }
}
