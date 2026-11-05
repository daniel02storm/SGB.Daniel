using UnityEngine;

public class Fire : Danger
{
    public override void OnPlayerHit(PlayerController player)
    {
        player.Die();
    }
}