using UnityEngine;

public enum EnemyState {Chill, Angry}
public class Enemy : Danger
{
    public Transform Victim;
    public float ZoomSpeed = 2f;
    private EnemyState mood = EnemyState.Chill;
    private float startPlace;
    private int walkPath = 1;
    private Rigidbody2D RB;

    void Start()
    {
        startPlace = transform.position.x;
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Mathf.Abs(Victim.position.x - transform.position.x);
        if (distance < 3f)
            mood = EnemyState.Angry;
        else
            mood = EnemyState.Chill;
        if (mood == EnemyState.Chill)
            WalkPast();
        else
            RunAtVictim();

        if (transform.position.y < -20f)
            Destroy(gameObject);
    }

    void WalkPast()
    {
        if (transform.position.x > startPlace + 2f)
            walkPath = -1;

        if (transform.position.x < startPlace - 2f)
            walkPath = 1;

        RB.linearVelocity = new Vector2(walkPath * ZoomSpeed, RB.linearVelocity.y);
    }

    void RunAtVictim()
    {
        if (Victim.position.x > transform.position.x)
            RB.linearVelocity = new Vector2(ZoomSpeed, RB.linearVelocity.y);
        else
            RB.linearVelocity = new Vector2(-ZoomSpeed, RB.linearVelocity.y);
    }
    public override void OnPlayerHit(PlayerController player)
    {
        player.Die();
    }
}