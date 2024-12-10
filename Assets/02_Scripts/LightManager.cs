using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LightManager : MonoBehaviour
{
    public UnityEngine.Light directionalLight; // Directional Light
    public UnityEngine.Light pointLight; // Point Light
    public float dimDuration = 10f; // Directional Light가 어두워지는 데 걸리는 시간
    public float pointLightIntensityRange = 0.4f; // Point Light의 최대 Intensity
    public float pointLightCycleDuration = 5f; // Point Light 밝기 변화 주기 (초)
    public XRGrabInteractable npcGrabInteractable; // NPC의 XR Grab Interactable

    private float initialDirectionalIntensity; // Directional Light 초기 밝기
    private float elapsedTime = 0f; // 경과 시간 추적
    private bool isIntensityLocked = false; // Point Light Intensity 고정 여부

    void Start()
    {
        // 초기 설정
        if (directionalLight != null)
        {
            initialDirectionalIntensity = directionalLight.intensity;
        }
        if (pointLight != null)
        {
            pointLight.gameObject.SetActive(false); // 처음에는 Point Light 비활성화
        }

        // XR Grab 이벤트 연결
        if (npcGrabInteractable != null)
        {
            npcGrabInteractable.selectEntered.AddListener(OnSelectEnter);
        }
    }

    void Update()
    {
        // Directional Light 어두워짐 로직
        if (directionalLight != null && elapsedTime < dimDuration)
        {
            elapsedTime += Time.deltaTime;

            // Intensity 감소
            float newIntensity = Mathf.Lerp(initialDirectionalIntensity, 0f, elapsedTime / dimDuration);
            directionalLight.intensity = newIntensity;

            // 색상 어두워짐 (선택 사항)
            directionalLight.color = Color.Lerp(Color.white, Color.black, elapsedTime / dimDuration);

            // Directional Light 비활성화 후 Point Light 활성화
            if (elapsedTime >= dimDuration)
            {
                directionalLight.gameObject.SetActive(false);
                if (pointLight != null)
                {
                    pointLight.gameObject.SetActive(true);
                }
            }
        }

        // Point Light Intensity 변동 로직
        if (pointLight != null && pointLight.gameObject.activeSelf && !isIntensityLocked)
        {
            // Intensity를 0에서 pointLightIntensityRange까지 반복적으로 변화
            float cycleTime = Time.time / pointLightCycleDuration; // 주기 조정
            pointLight.intensity = Mathf.PingPong(cycleTime, pointLightIntensityRange);
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        // Point Light Intensity를 0.2로 고정
        if (pointLight != null)
        {
            isIntensityLocked = true; // Intensity 변동 중지
            pointLight.intensity = 0.2f;
        }
    }

    private void OnDestroy()
    {
        // 이벤트 해제
        if (npcGrabInteractable != null)
        {
            npcGrabInteractable.selectEntered.RemoveListener(OnSelectEnter);
        }
    }
}
