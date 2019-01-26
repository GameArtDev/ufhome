using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{

    public int damage = 1;
    public bool hitted = false;

    void Start()
    {
        Destroy(gameObject, 20);
    }


}
