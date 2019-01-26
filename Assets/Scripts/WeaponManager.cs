using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponManager : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;

            shotTransform.position = transform.position;

            ShotManager shot = shotTransform.gameObject.GetComponent<ShotManager>();
            if (shot != null)
            {
                shot.hitted = isEnemy;
            }

            EnemyMoves move = shotTransform.gameObject.GetComponent<EnemyMoves>();
            if (move != null)
            {
                move.direction = this.transform.right; 
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}