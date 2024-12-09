using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Scene nowScene = SceneManager.GetActiveScene();

        switch (nowScene.name)
        {
            case "01_ForestStage":
                SceneManager.LoadScene("02_FactoryStage");
                break;
            case "02_FactoryStage":
                SceneManager.LoadScene("03_SeaStage");
                break;
            case "03_SeaStage":
                SceneManager.LoadScene("04_MainStage");
                break;


        }
    }
}

