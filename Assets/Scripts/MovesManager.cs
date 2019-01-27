using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesManager : MonoBehaviour
{
    public float amplitudeX = 10.0f;
    public float amplitudeY = 5.0f;
    public float omegaX = 1.0f;
    public float omegaY = 5.0f;
    float index;
    AudioSource myAudiosource;
    public GameObject deathEffect;


    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public Vector3 startPosition;

    public void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        index += Time.deltaTime;
        float x = startPosition.x + (amplitudeX * Mathf.Cos(omegaX * index));
        float y = startPosition.y + Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(x, y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "laser")
        {
            myAudiosource.Play();
            CallDestroy();
        }

        if (other.gameObject.tag == "Player")
        {
            deathEffect.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(deathEffect);
        }
    }

    void CallDestroy()
    {
        Destroy(gameObject, 0.5F);

    }
}
