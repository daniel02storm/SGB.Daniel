using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string GameScene;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(GameScene);
    }
}