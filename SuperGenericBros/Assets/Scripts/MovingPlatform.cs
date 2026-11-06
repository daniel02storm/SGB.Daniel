using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    int direction = 1;
    float startPlace;
    float move;

    void Start()
    {
        startPlace = transform.position.x;
    }

    void FixedUpdate()
    {
        if (transform.position.x > startPlace + 6)
            direction = -1;

        if (transform.position.x < startPlace - 6)
            direction = 1;

        move = direction * 3f * Time.fixedDeltaTime;
        transform.Translate(move, 0, 0);
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
            other.transform.Translate(move, 0, 0);
    }
}