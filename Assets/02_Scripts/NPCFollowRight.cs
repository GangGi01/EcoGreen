using UnityEngine;

public class NPCFollowRight : MonoBehaviour
{
    public Transform player; // 플레이어 Transform (XR Origin의 Camera Rig)
    public Vector3 offset = new Vector3(1.5f, 0, 0); // 오른쪽 기준 오프셋
    public float moveSpeed = 5f; // 이동 속도

    private bool isFollowing = false;

    void Update()
    {
        if (isFollowing)
        {
            // 목표 위치 계산: 플레이어의 오른쪽 가장자리
            Vector3 targetPosition = player.position + player.right * offset.x + player.up * offset.y + player.forward * offset.z;

            // NPC를 목표 위치로 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // NPC가 플레이어를 바라보게 회전
            Vector3 lookDirection = player.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), moveSpeed * Time.deltaTime);
        }
    }

    // XR Grab 해제 시 호출
    public void StartFollowing()
    {
        isFollowing = true;
    }

    // XR Grab 시작 시 호출
    public void StopFollowing()
    {
        isFollowing = false;
    }
}
