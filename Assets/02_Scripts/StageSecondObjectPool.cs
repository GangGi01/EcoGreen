using System.Collections.Generic;
using UnityEngine;

public class StageSecondObjectPool : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 소환할 오브젝트 종류 배열
    public int poolSize = 20;         // 풀 크기

    private Queue<GameObject> objectPool;

    void Start()
    {
        objectPool = new Queue<GameObject>();

        // 풀 초기화
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefabs[i % objectPrefabs.Length]);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    // 오브젝트 활성화
    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if (objectPool.Count == 0) return null;

        GameObject obj = objectPool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }

    // 오브젝트 비활성화 및 다시 풀로 반환
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
