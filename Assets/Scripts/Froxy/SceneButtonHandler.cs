using UnityEngine;

public class SceneButtonHandler : MonoBehaviour
{
    [SerializeField] private SceneLoadManager sceneLoadManager; // SceneLoadManager 참조
    [SerializeField] private string sceneName; // 전환할 씬 이름

    public void OnSceneChangeButtonClick()
    {
        if (sceneLoadManager != null)
        {
            sceneLoadManager.ChangeScene(sceneName);
        }
        else
        {
            Debug.LogError("SceneLoadManager is not assigned.");
        }
    }
}