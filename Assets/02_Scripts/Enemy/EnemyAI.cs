using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyAI : MonoBehaviour
{
    public GameObject buildingPrefab; // 건설할 건물 프리팹
    public Transform[] buildLocations; // 건설 가능한 위치 배열

    private int resources = 0; // 현재 자원량
    private int maxResources = 10; // 최대 자원량
    private float resourcesRegenRate = 1f; // 자원 회복 속도

    private int buildCost = 3;

    private void Start()
    {
        //자원 회복 코루틴 시작
        StartCoroutine(RegenerateResource());
    }

    private void Update()
    {
        if (resources >= buildCost)
        {
            BuildStructure();
        }
    }

    // 자원 회복 
    private IEnumerator RegenerateResource()
    {
        while (true)
        {
            yield return new WaitForSeconds(resourcesRegenRate);

            if (resources < maxResources)
            {
                resources++;
            }
        }
    }
    
    private void BuildStructure()
    {
        // 건설 가능한 위치 중 무작위로 선택
        Transform buildLocation = new GameObject("TestLocation").transform;
        buildLocation.position = Vector3.zero;

        // 이미 해당 위치에 건물이 있는지 확인
        Collider[] colliders = Physics.OverlapSphere(buildLocation.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("ENEMYTOWER"))
            {
                Debug.Log("이미 건물이 있는 위치입니다. 건설을 건너뜁니다.");
                return;
            }
        }

        // 건물 생성
        resources -= buildCost;
        Instantiate(buildingPrefab, buildLocation.position, Quaternion.identity);
        Debug.Log($"건물이 {buildLocation.position} 위치에 건설되었습니다.");
    }
}
