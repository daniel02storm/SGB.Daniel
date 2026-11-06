using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource Source;
    public AudioClip JumpSound;
    public AudioClip DeathSound;
    public AudioClip WinSound;

    void Awake()
    {
        Instance = this;
    }

    public void JumpPlay()
    {
        Source.PlayOneShot(JumpSound);
    }
    public void DeathPlay()
    {
        Source.PlayOneShot(DeathSound);
    }
    public void WinPlay()
    {
        Source.PlayOneShot(WinSound);
    }
}