using UnityEngine;

public class Enemy1CollisionChecking : MonoBehaviour
{
    private HealthSystem enemyHealth;
    [SerializeField] private int maxHealthEnemy;

    void Awake()
    {
        enemyHealth = new HealthSystem(maxHealthEnemy, maxHealthEnemy);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("PlayerShot")){
            enemyHealth.DealDamage(1);
            if(enemyHealth.Health == 0){
                //Enemy Death
                Destroy(gameObject);
            }
        }
    }
}
