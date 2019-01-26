using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public Vector2 speed = new Vector2(25, 25);

    private Vector2 movement;
    private Rigidbody2D rigidBodyComponent;
    public GameObject shipLaser;


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);
 
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(
                  Mathf.Clamp(transform.position.x, leftBorder + 2, rightBorder - 2),
                  Mathf.Clamp(transform.position.y, topBorder + 1, bottomBorder - 1),
                  transform.position.z
                  );

        if ((Input.GetKeyDown(KeyCode.Space)))
            shipLaser.SetActive(true);
    }

    void FixedUpdate()
    {
        if (rigidBodyComponent == null) rigidBodyComponent = GetComponent<Rigidbody2D>();
        rigidBodyComponent.velocity = movement;
    }





}
