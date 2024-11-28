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
            case "ForestStage":
                SceneManager.LoadScene("FactoryStage");
                break;
            case "FactoryStage":
                SceneManager.LoadScene("SeaStage");
                break;
            case "SeaStage":
                SceneManager.LoadScene("MainStage");
                break;


        }
    }
}

