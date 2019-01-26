using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool hasSpawn;
    private EnemyMoves moves;
    private WeaponManager[] weapons;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponManager>();
        moves = GetComponent<EnemyMoves>();
    }

    void Start()
    {
        hasSpawn = false;

        GetComponent<Collider2D>().enabled = false;
        moves.enabled = false;

        foreach (WeaponManager weapon in weapons)
        {
            weapon.enabled = false;
        }

    }

    void Update()
    {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponManager weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    void Spawn()
    {
        hasSpawn = true;

        GetComponent<Collider2D>().enabled = true;
        moves.enabled = true;
        foreach (WeaponManager weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
