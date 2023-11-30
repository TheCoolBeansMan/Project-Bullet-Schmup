using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int current = 0;

    public float speed = 0.3f;

    private void FixedUpdate()
    {
        if (transform.position != waypoints[current].position)
        {
            Vector2 position = Vector2.MoveTowards(transform.position, waypoints[current].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(position);
        }
        else
        {
            current = (current + 1) % waypoints.Length;
        }

        if (gameObject.transform.position.y < -9 || gameObject.transform.position.y > 9 || gameObject.transform.position.x < -10 || gameObject.transform.position.x > 10)
            Destroy(gameObject);

        Vector2 direction = waypoints[current].position - transform.position;
    }
}
