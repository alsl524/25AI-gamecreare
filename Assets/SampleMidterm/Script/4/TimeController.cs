using UnityEngine;
using UnityEngine.InputSystem;

public class TimeController : MonoBehaviour
{
    [Tooltip("슬로우 모션 값")]
    public float slowScale = 0.2f;
    public float normalScale = 1f;

    void Start()
    {
        Time.timeScale = normalScale;
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.tKey.wasPressedThisFrame)
        {
            Time.timeScale = Mathf.Approximately(Time.timeScale, normalScale) ? slowScale : normalScale;
            // FixedDeltaTime도 같이 보정 (권장)
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Debug.Log("TimeScale = " + Time.timeScale);
        }
    }
}
