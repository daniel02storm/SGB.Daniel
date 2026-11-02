using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State {Playing, Won, Lost}
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StatusText;
    public static GameManager Instance;
    public State GameState = State.Playing;
    public PlayerController Player;
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (GameState != State.Playing && Input.GetKeyDown(KeyCode.R))
            Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
