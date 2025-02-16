using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
