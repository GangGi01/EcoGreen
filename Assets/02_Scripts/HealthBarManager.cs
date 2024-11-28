using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Slider healthBar;
    public float healthIncrement = 0.5f;
    public float additionalIncreementPerObject = 0.1f;

    private int objectCount = 0;
    private float currentHealth = 0f;

    private void Start()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    public void OnTowerPlaced()
    {
        objectCount++;
        StartCoroutine(UpdateHealth());
    }

    IEnumerator UpdateHealth()
    {
        if (healthBar != null)
        {
            currentHealth += healthIncrement;
            currentHealth = Mathf.Clamp(currentHealth, 0f, 1f);
            healthBar.value = currentHealth;
        }

        yield return new WaitForSeconds(0.5f);
    }
}
