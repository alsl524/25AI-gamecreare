using UnityEngine;

public class CubeA_FrameMove : MonoBehaviour
{
    public float Speed = 1f; // units per frame (!) — 프레임 종속

    void Update()
    {
        // 프레임마다 오른쪽으로 Speed 만큼 이동 (프레임률에 따라 속도 달라짐)
        transform.Translate(Vector3.right * Speed);
    }
}
