using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyAI : MonoBehaviour
{
    public GameObject buildingPrefab; // 건설할 건물 프리팹
    public GameObject buildPointsGroup;
    
    public List<Transform> buildingPoints = new List<Transform>(); // 건설 가능한 위치 배열

    private int resources = 0; // 현재 자원량
    private int maxResources = 10; // 최대 자원량
    private float resourcesRegenRate = 1f; // 자원 회복 속도

    private int buildCost = 3;

    private void Start()
    {
        //자원 회복 코루틴 시작
        StartCoroutine(RegenerateResource());

        foreach (Transform child in buildPointsGroup.transform)
        {
            buildingPoints.Add(child);
        }
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
        if (buildingPoints.Count > 0) // 자원이 충분하고 건설 위치가 남아있는 경우
        {
            resources -= buildCost; // 자원 차감

            // 랜덤으로 위치 선택
            int randomIndex = Random.Range(0, buildingPoints.Count);
            Transform buildPoint = buildingPoints[randomIndex];

            // 선택된 위치에 건물 생성
            Instantiate(buildingPrefab, buildPoint.position, Quaternion.identity);
            Debug.Log($"건물이 {buildPoint.position}에 건설되었습니다.");

            // 사용된 위치 제거
            buildingPoints.RemoveAt(randomIndex);
        }
    }
}
