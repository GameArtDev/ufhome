using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    public float amplitudeY = 5.0f;
    public float omegaY = 5.0f;

    float index;

    void Update()
    {
        index += Time.deltaTime;

        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
        //amplitudeY * Mathf.Sin(omegaY * index));
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
