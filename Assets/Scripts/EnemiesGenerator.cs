using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    public GameObject enemie;
    private Vector3 spawnPosition;

    void Start()
    {
        //spawnPosition.x = Random.Range(-17, 17);
        //spawnPosition.y = 0.5f;
        //spawnPosition.z = Random.Range(-17, 17);
        //Instantiate(enemie, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        //if (transform.childCount < 3)
        //{
        //    spawnPosition.x = Random.Range(-17, 17);
        //    spawnPosition.y = 0.5f;
        //    spawnPosition.z = Random.Range(-17, 17);
        //    Instantiate(enemie, spawnPosition, Quaternion.identity);
        //}
    }
}
