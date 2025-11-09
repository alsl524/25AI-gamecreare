using UnityEngine;

public class PoopManager : MonoBehaviour
{
    public GameObject poopPrefab;
    public float spawnInterval = 1.5f;
    public float rangeX = 8f;
    public float startY = 6f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPoop();
            timer = 0f;
        }
    }

    void SpawnPoop()
    {
        float randX = Random.Range(-rangeX, rangeX);
        Vector3 pos = new Vector3(randX, startY, 0);
        GameObject poop = Instantiate(poopPrefab, pos, Quaternion.identity);
        Destroy(poop, 5f); // 5초 후 자동 삭제
    }
}
