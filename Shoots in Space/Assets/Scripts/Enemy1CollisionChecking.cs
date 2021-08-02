using UnityEngine;

public class Enemy1CollisionChecking : MonoBehaviour
{
    //Private variables
    private const int ENEMY_SCORE_POINT = 10;
    private HealthSystem enemyHealth;
    [SerializeField] private int maxHealthEnemy;

    void Awake()
    {
        enemyHealth = new HealthSystem(maxHealthEnemy);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If an enemy collides with the player shot or the main player, it gets damaged by 1
        if(collider.gameObject.CompareTag("PlayerShot") || collider.gameObject.CompareTag("MainPlayer")){
            enemyHealth.DealDamage(1);
            if(enemyHealth.Health == 0){
                //Enemy Death
                Destroy(gameObject);
                //Update score text
                Score.score += ENEMY_SCORE_POINT;
            }
        }
    }
}
