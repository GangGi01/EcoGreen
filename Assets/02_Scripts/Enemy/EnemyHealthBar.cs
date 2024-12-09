using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public string enemyBuildingTag = "ENEMYTOWER";
    public int maxBuildingCount = 10;
    
    void Start()
    {
        if (slider != null)
        {
            slider.value = 0f; // 초기화
        }

        StartCoroutine(UpdateSliderRoutine());

    }

    private IEnumerator UpdateSliderRoutine()
    {
        while (true)
        {
            UpdateSlider();
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void UpdateSlider()
    {
        int currentBuildingCount = GameObject.FindGameObjectsWithTag(enemyBuildingTag).Length;

        if (slider != null)
        {
            slider.value = Mathf.Clamp01((float)currentBuildingCount / maxBuildingCount);
        }
        
    }
    
}
