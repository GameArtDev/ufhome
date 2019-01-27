using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private bool hasSpawn;
    private EnemyMoves moves;
    private WeaponManager[] weapons;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;
    public float destroyTime;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponManager>();
        moves = GetComponent<EnemyMoves>();
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hasSpawn = false;
        coliderComponent.enabled = true;
        //GetComponent<Collider2D>().enabled = false;
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
            else
            {
                GetComponent<Collider2D>().enabled = true;
                moves.enabled = true;
            }
        }
        else
        {
            foreach (WeaponManager weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    float playerHeight = 1.24f;

                    if (GameObject.FindGameObjectWithTag("Player") != null)
                    {
                        playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>().bounds.size.y;

                        float playerUppeberBound = GameObject.FindGameObjectWithTag("Player").transform.position.y + (playerHeight / 2);
                        float playerLowerBoud = GameObject.FindGameObjectWithTag("Player").transform.position.y - (playerHeight / 2);


                        if (transform.position.y >= playerLowerBoud && transform.position.y <= playerUppeberBound)
                        {
                            weapon.Attack(true);
                        }
                    }
                }
            }

            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject, destroyTime);
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
