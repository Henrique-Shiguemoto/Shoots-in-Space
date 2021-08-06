using UnityEngine;

public class Enemy2CollisionChecking : MonoBehaviour
{
    private const int ENEMY_SCORE_POINT = 20;
    private HealthSystem enemyHealth;
    private Enemy2Spawner enemy2Spawner;
    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private Animator animator;

    void Awake()
    {
        enemyHealth = new HealthSystem(enemyMaxHealth);
    }

    void Start()
    {
        enemy2Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy2Spawner>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("PlayerShot") || collider.gameObject.CompareTag("MainPlayer")){
            int damageDealt;
            if(collider.gameObject.CompareTag("PlayerShot")){
                damageDealt = 2;
            }else{
                damageDealt = 1;
            }
            enemyHealth.DealDamage(damageDealt);
            if(enemyHealth.Health == 0){
                FindObjectOfType<AudioManager>().PlaySound("EnemyExplosion");
                animator.SetTrigger("TriggerExplosion"); //need to wait for the animation to destroy
                Destroy(gameObject);
                Score.score += ENEMY_SCORE_POINT;
                enemy2Spawner.waveEnemyCount--;
            }
        }
    }
}
