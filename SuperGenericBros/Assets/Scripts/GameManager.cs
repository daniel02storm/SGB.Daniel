using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum State {Playing, Won, Lost}
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StatusText;
    public static GameManager Instance;
    public State GameState = State.Playing;
    public PlayerController Player;
    public GameObject RestartButton;
    public GameObject MenuButton;
    public string StartMenu;
    private List<Danger> allDangers = new List<Danger>();
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Player.Died += Lose;
        allDangers.AddRange(FindObjectsByType<Danger>(FindObjectsSortMode.None));
        StatusText.text = "Find the coin!";
        RestartButton.SetActive(false);
        MenuButton.SetActive(false);
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
        StopDangers();
        AudioManager.Instance.WinPlay();
        StatusText.text = "We're rich!";
        Debug.Log("Win");
        RestartButton.SetActive(true);
        MenuButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Lose()
    {
        if (GameState != State.Playing) return;
        GameState = State.Lost;
        StopDangers();
        StatusText.text = "Game over!";
        Debug.Log("Defeat");
        RestartButton.SetActive(true);
        MenuButton.SetActive(true);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(StartMenu);
    }
    void StopDangers()
    {
        foreach (Danger danger in allDangers)
        {
            if (danger != null)
                danger.enabled = false;
        }
    }
}
