using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    int direction = 1;
    float startPlace;

    void Start()
    {
        startPlace = transform.position.x;
    }

    void Update()
    {
        if (transform.position.x > startPlace + 6)
            direction = -1;

        if (transform.position.x < startPlace - 6)
            direction = 1;

        transform.Translate(direction * 4f * Time.deltaTime, 0, 0);
    }
}