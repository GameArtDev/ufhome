using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public float speed = 1.0f;
    public float Horizontal_Start_Position = 3.0f;
    public float Horizontal_Range = 0.0f;
    public float Vertical_Range = 0.0f;
    private Rigidbody2D rb2d;  
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") - Horizontal_Start_Position;
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * Horizontal_Range, moveVertical * Vertical_Range);

        transform.position = movement;
        rb2d.AddForce(movement * speed);
    }

    void FixedUpdate()
    {

    }
}
