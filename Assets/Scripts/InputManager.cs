using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public float speed = 1.0f;     
    private Rigidbody2D rb2d;  
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float position = 0.0f;

        position += moveHorizontal;

        Vector2 movement = new Vector2(position, moveVertical);

        transform.position = movement;
        rb2d.AddForce(movement * speed);
    }

    void FixedUpdate()
    {

    }
}
