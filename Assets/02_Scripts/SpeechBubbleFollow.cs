using UnityEngine;

public class SpeechBubbleFollow : MonoBehaviour
{
    public Transform npcTransform;
    public Vector3 offset = new Vector3(0, 2, 0);

    private void Update()
    {
        // NPC 위치 + 오프셋으로 말풍선 위치 고정
        transform.position = npcTransform.position + offset;
    }
}
