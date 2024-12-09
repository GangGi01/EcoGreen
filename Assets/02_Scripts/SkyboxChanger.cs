using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material skyboxMaterial; // Skybox/Panoramic Material
    public Texture clearSkyTexture; // 화창한 스카이 텍스처
    public Texture cloudySkyTexture; // 먹구름 스카이 텍스처
    public float transitionDuration = 10f; // 전환 시간

    private float transitionProgress = 0f; // 전환 진행 상태 (0에서 1로 변함)
    private bool isTransitioning = false;

    void Start()
    {
        // 초기 스카이박스 설정
        if (skyboxMaterial != null && clearSkyTexture != null)
        {
            skyboxMaterial.SetTexture("_MainTex", clearSkyTexture);
            RenderSettings.skybox = skyboxMaterial;
            StartCoroutine(TransitionSkybox());
        }
        else
        {
            Debug.LogError("Skybox Material 또는 Texture가 설정되지 않았습니다!");
        }
    }

    private System.Collections.IEnumerator TransitionSkybox()
    {
        isTransitioning = true;

        // 초기 텍스처에서 최종 텍스처로 전환
        while (transitionProgress < 1f)
        {
            transitionProgress += Time.deltaTime / transitionDuration;

            // 텍스처 보간 대신 Exposure를 활용하여 전환 효과
            skyboxMaterial.SetFloat("_Exposure", Mathf.Lerp(1f, 0.3f, transitionProgress)); // 노출 조정
            skyboxMaterial.SetTexture("_MainTex", clearSkyTexture); // 항상 초기 텍스처 사용

            // 실제 텍스처 변경을 천천히 반영
            if (transitionProgress >= 0.5f)
            {
                skyboxMaterial.SetTexture("_MainTex", cloudySkyTexture); // 변경 시점
            }

            yield return null;
        }

        // 전환 완료
        skyboxMaterial.SetTexture("_MainTex", cloudySkyTexture);
        skyboxMaterial.SetFloat("_Exposure", 0.3f); // 최종 노출 값
        isTransitioning = false;
    }
}
