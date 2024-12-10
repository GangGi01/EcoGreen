using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCAnimationController : MonoBehaviour
{
    public XRGrabInteractable npcGrabInteractable; // NPC의 XR Grab Interactable
    public Animator npcAnimator; // NPC의 Animator
    private static readonly int StaunParam = Animator.StringToHash("Staun"); // Staun 애니메이션 파라미터
    private static readonly int NoAnimationParam = Animator.StringToHash("NoAnimation"); // 애니메이션이 없도록 할 파라미터

    void Start()
    {
        // XR Grab 이벤트 등록
        if (npcGrabInteractable != null)
        {
            npcGrabInteractable.selectEntered.AddListener(OnSelectEnter);
            npcGrabInteractable.selectExited.AddListener(OnSelectExit);
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (npcAnimator != null)
        {
            npcAnimator.SetBool(StaunParam, true); // Staun 애니메이션 시작
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        if (npcAnimator != null)
        {
            npcAnimator.SetBool(StaunParam, false); // Staun 애니메이션 종료
            npcAnimator.SetTrigger(NoAnimationParam); // 애니메이션을 끄는 트리거를 설정
        }
    }

    private void OnDestroy()
    {
        // 이벤트 해제
        if (npcGrabInteractable != null)
        {
            npcGrabInteractable.selectEntered.RemoveListener(OnSelectEnter);
            npcGrabInteractable.selectExited.RemoveListener(OnSelectExit);
        }
    }
}
