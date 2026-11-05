using UnityEngine;

public abstract class Danger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            OnPlayerHit(player);
    }
    public abstract void OnPlayerHit(PlayerController player);
}