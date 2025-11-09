using UnityEngine;
using UnityEngine.InputSystem; // 새 입력 시스템 사용

[RequireComponent(typeof(SpriteRenderer))]
public class BG_Scroller : MonoBehaviour
{
    [Tooltip("초당 이동 속도 (x=가로, y=세로)")]
    public Vector2 scrollSpeed = new Vector2(0.2f, 0f);

    private Material bgMaterial;
    private Vector2 offset = Vector2.zero;

    void Start()
    {
        // SpriteRenderer에서 머티리얼 가져오기
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        bgMaterial = sr.material;
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        Vector2 move = Vector2.zero;

        // 방향키 입력
        if (kb.upArrowKey.isPressed) move.y += 1;
        if (kb.downArrowKey.isPressed) move.y -= 1;
        if (kb.leftArrowKey.isPressed) move.x -= 1;
        if (kb.rightArrowKey.isPressed) move.x += 1;

        // 시간에 따른 이동량 (DeltaTime 적용)
        offset += move * scrollSpeed * Time.deltaTime;

        // 머티리얼 Offset 적용
        bgMaterial.mainTextureOffset = offset;
    }
}
