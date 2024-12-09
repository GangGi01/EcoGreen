using UnityEngine;

public class TriggerOnParticle : MonoBehaviour
{
    public GameObject particleObject; // 활성화/비활성화할 파티클 오브젝트
    public string targetTag = "NPC"; // 충돌 대상 태그 (예: NPC)

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 대상이 특정 태그를 가진 경우
        if (other.CompareTag(targetTag))
        {
            if (particleObject != null)
            {
                // 오브젝트 활성화
                particleObject.SetActive(true);
                Debug.Log("파티클 오브젝트 활성화!");
            }
        }
    }
}
