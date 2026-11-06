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
    void Start()
    {
        Player.Died += Lose;
        StatusText.text = "Find the coin!";
        RestartButton.SetActive(false);
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
        StatusText.text = "We're rich!";
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
