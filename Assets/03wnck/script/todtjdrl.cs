using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;           // 가시 프리팹
    float spawnInterval = 4.0f;              // 스폰 간격 (초)
    public float spikeSpacing = 1.0f;        // 같은 패턴 내 가시 간격

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // 한 패턴마다 가시 개수 랜덤 (1~3)
            int spikeCount = Random.Range(1, 4);
            Debug.Log("이번 패턴 가시 수: " + spikeCount);

            // spikeCount 만큼 생성
            for (int i = 0; i < spikeCount; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(i * spikeSpacing, 0f, 0f);
                Instantiate(spikePrefab, spawnPos, Quaternion.identity);
            }

            // 다음 패턴 나오기 전 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
