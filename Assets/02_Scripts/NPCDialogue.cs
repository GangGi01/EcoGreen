using System.Collections;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject speechBubble;  // 말풍선 UI 오브젝트
    public TMP_Text dialogueText;       // 말풍선 안의 Text 컴포넌트
    public RectTransform bubbleRect; // 말풍선 Panel의 RectTransform
    public string[] dialogues;      // NPC의 대사 리스트
    public float dialogueDuration = 3.0f; // 말풍선 표시 시간
    public Vector2 padding = new Vector2(20, 20); // 텍스트 주위 패딩

    private int currentDialogueIndex = 0; // 현재 대사 인덱스
    private Coroutine dialogueCoroutine;

    private void Start()
    {
        speechBubble.SetActive(false); // 시작 시 말풍선을 숨김
    }

    public void EnableSpeechBubble()
    {
        if (dialogueCoroutine == null)
        {
            ShowNextDialogue();
        }
    }

    public void DisableSpeechBubble()
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
        }

        speechBubble.SetActive(false); // 말풍선 비활성화
    }

    public void ShowNextDialogue()
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }

        dialogueCoroutine = StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        // 말풍선 활성화 및 대사 설정
        speechBubble.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];


        // 3초 동안 대사 표시
        yield return new WaitForSeconds(dialogueDuration);

        // 다음 대사로 전환
        currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Length;

        // 말풍선 비활성화
        speechBubble.SetActive(false);

        // 다음 대사 표시를 위한 딜레이
        yield return new WaitForSeconds(0.5f); // 필요하면 추가적인 딜레이
        ShowNextDialogue();
    }


}
