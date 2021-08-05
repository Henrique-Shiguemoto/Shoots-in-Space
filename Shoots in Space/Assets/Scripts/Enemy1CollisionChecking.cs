using UnityEngine;

public class Enemy1CollisionChecking : MonoBehaviour
{
    //Private variables
    private const int ENEMY_SCORE_POINT = 10;
    private HealthSystem enemyHealth;
    private Enemy1Spawner enemy1Spawner;
    [SerializeField] private int maxHealthEnemy;

    void Awake()
    {
        enemyHealth = new HealthSystem(maxHealthEnemy);
    }

    void Start()
    {
        enemy1Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If an enemy collides with the player shot or the main player, it gets damaged by 1
        if(collider.gameObject.CompareTag("PlayerShot") || collider.gameObject.CompareTag("MainPlayer")){
            int damageAmount = 0;
            if(collider.gameObject.CompareTag("PlayerShot")){
                damageAmount = 2;
            }else{
                damageAmount = 1;
            }
            enemyHealth.DealDamage(damageAmount);
            if(enemyHealth.Health == 0){
                //Enemy Death
                Destroy(gameObject);
                //Update score text
                Score.score += ENEMY_SCORE_POINT;
                //Updating enemy wave count
                enemy1Spawner.waveEnemyCount--;
            }
        }
    }
}
