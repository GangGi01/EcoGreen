using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public StageSecondObjectPool objectPool;   // ObjectPool 스크립트 참조
    public float spawnInterval = 2f; // 소환 간격
    public Transform[] spawnPoints;    // 소환 위치

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        if (spawnPoints.Length == 0) return;

        // 랜덤으로 소환 위치 선택
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[randomIndex];

        Vector3 spawnPosition = chosenSpawnPoint.position;
        Quaternion spawnRotation = Quaternion.identity; // 기본 회전값

        // Object Pool에서 오브젝트 가져오기
        GameObject obj = objectPool.GetObject(spawnPosition, spawnRotation);

        if (obj != null)
        {
            // 오브젝트를 일정 시간 후 다시 풀로 반환
            StartCoroutine(ReturnToPoolAfterSeconds(obj, 5f));
        }
    }

    private System.Collections.IEnumerator ReturnToPoolAfterSeconds(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.ReturnObject(obj);
    }
}
