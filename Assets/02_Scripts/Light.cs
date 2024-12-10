using UnityEngine;


public class Light : MonoBehaviour
{
    public UnityEngine.Light targetLight;
    public float dimDuration = 10f; // 조명이 어두워지는 데 걸리는 시간
    private float initialIntensity; // 초기 밝기 저장
    private float elapsedTime = 0f; // 경과 시간 추적

    void Start()
    {
        // 초기 밝기를 저장
        if (targetLight != null)
        {
            initialIntensity = targetLight.intensity;
        }
    }

    void Update()
    {
        if (targetLight != null && elapsedTime < dimDuration)
        {
            elapsedTime += Time.deltaTime;

            // Intensity 감소
            float newIntensity = Mathf.Lerp(initialIntensity, 0f, elapsedTime / dimDuration);
            targetLight.intensity = newIntensity;

            // 색상도 어두워지도록 설정 (선택 사항)
            targetLight.color = Color.Lerp(Color.white, Color.black, elapsedTime / dimDuration);
        }
        // 조명이 완전히 어두워진 경우 오브젝트 비활성화
        if (elapsedTime >= dimDuration)
        {
            gameObject.SetActive(false);
        }
    }
}

