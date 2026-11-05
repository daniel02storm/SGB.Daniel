using UnityEngine;

public enum EnemyState {Chill, Angry}
public class Enemy : Danger
{
    public Transform Victim;
    public float ZoomSpeed = 2f;
    private EnemyState mood = EnemyState.Chill;
    private float startPlace;
    private int walkPath = 1;

    void Start()
    {
        startPlace = transform.position.x;
    }

    void Update()
    {
        float distance = Mathf.Abs(Victim.position.x - transform.position.x);
        if (distance < 2f)
            mood = EnemyState.Angry;
        else
            mood = EnemyState.Chill;
        if (mood == EnemyState.Chill)
            WalkPast();
        else
            RunAtVictim();
    }

    void WalkPast()
    {
        if (transform.position.x > startPlace + 2f)
            walkPath = -1;

        if (transform.position.x < startPlace - 2f)
            walkPath = 1;

        transform.Translate(walkPath * ZoomSpeed * Time.deltaTime, 0, 0);
    }

    void RunAtVictim()
    {
        if (Victim.position.x > transform.position.x)
            transform.Translate(ZoomSpeed * Time.deltaTime, 0, 0);
        else
            transform.Translate(-ZoomSpeed * Time.deltaTime, 0, 0);
    }
    public override void OnPlayerHit(PlayerController player)
    {
        player.Die();
    }
}