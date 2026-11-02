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
    public GameObject RestartButton;
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (GameState != State.Playing && Input.GetKeyDown(KeyCode.R))
            Restart();
    }
    public void Win()
    {
        if (GameState != State.Playing) return;
        GameState = State.Won;
        StatusText.text = "Victory!";
        Debug.Log("Win");
        RestartButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Lose()
    {
        if (GameState != State.Playing) return;
        GameState = State.Lost;
        StatusText.text = "Game over!";
        Debug.Log("Defeat");
        RestartButton.SetActive(true);
    }
}
