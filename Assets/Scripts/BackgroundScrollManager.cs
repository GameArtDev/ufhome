using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollManager : MonoBehaviour
{
    public float ScrollSpeed = 0.2f;
    public float TileSize;
    public float MaxScrollSpeed = 0.5f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float newPosition = Mathf.Repeat(Time.time * ScrollSpeed, TileSize);

        if (moveVertical == 1.0f)
        {
            moveVertical = 1.0f;
            transform.position = startPosition + new Vector3(-1 * moveHorizontal * newPosition, moveVertical, 0);
        }
        else if (moveVertical == -1.0f)
        {
            moveVertical = -1.0f;
            transform.position = startPosition + new Vector3(-1 * moveHorizontal * newPosition, moveVertical, 0);
        }
        else
        {
            ScrollSpeed = MaxScrollSpeed;
            transform.position = startPosition + new Vector3(-1 * moveHorizontal * newPosition, moveVertical, 0);
        }
    }
}
