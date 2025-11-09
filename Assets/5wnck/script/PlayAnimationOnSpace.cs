using UnityEngine;
using UnityEngine.InputSystem;  // ✅ 새 입력 시스템 네임스페이스

public class PlayAnimationOnSpace : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)  // ✅ 새 Input 방식
        {
            animator.Play("Jump");
        }
    }
}
