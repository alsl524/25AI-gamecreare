using UnityEngine;

public class CubeB_DeltaMove : MonoBehaviour
{
    public float Speed = 2f; // units per second

    void Update()
    {
        // DeltaTime을 곱해 프레임 독립적으로 이동
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
