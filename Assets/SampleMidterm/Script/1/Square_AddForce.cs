using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Square_AddForce : MonoBehaviour
{
    public float Speed = 200f;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        var kb = Keyboard.current;
        Vector2 force = Vector2.zero;

        if (kb.leftArrowKey.isPressed) force.x -= 1f;
        if (kb.rightArrowKey.isPressed) force.x += 1f;
        if (kb.upArrowKey.isPressed) force.y += 1f;
        if (kb.downArrowKey.isPressed) force.y -= 1f;

        rb.AddForce(force.normalized * Speed * Time.deltaTime, ForceMode2D.Force);
    }
}
