using UnityEngine;

public class Enemy1CollisionChecking : MonoBehaviour
{
    //Private variables
    private const int ENEMY_SCORE_POINT = 10;
    private HealthSystem enemyHealth;
    private Enemy1Spawner enemy1Spawner;
    private Collider2D enemyCollider;
    [SerializeField] private int maxHealthEnemy;
    [SerializeField] private Animator animator;

    void Awake()
    {
        enemyHealth = new HealthSystem(maxHealthEnemy);
    }

    void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        enemy1Spawner = GameObject.Find("EnemySpawner").GetComponent<Enemy1Spawner>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If an enemy collides with the player shot or the main player, it gets damaged by 1
        if(collider.gameObject.CompareTag("PlayerShot") || collider.gameObject.CompareTag("MainPlayer") || 
            collider.gameObject.CompareTag("SpecialAbility")){
            int damageAmount = 0;
            if(collider.gameObject.CompareTag("PlayerShot")){
                damageAmount = 2;
            }else if(collider.gameObject.CompareTag("MainPlayer")){
                damageAmount = 1;
            }else{
                damageAmount = 4;
            }
            enemyHealth.DealDamage(damageAmount);
            if(enemyHealth.Health == 0){
                FindObjectOfType<AudioManager>().PlaySound("EnemyExplosion");
                animator.SetTrigger("TriggerExplosion");
                //Disable collider first
                enemyCollider.enabled = false;
                //Deactivate shooting
                gameObject.GetComponent<Enemy1Shoot>().enabled = false;
                Invoke("Kill", 1.2f);
                //Update score text
                Score.score += ENEMY_SCORE_POINT;
                //Updating enemy wave count
                enemy1Spawner.waveEnemyCount--;
            }
        }
    }

    void Kill(){
        Destroy(gameObject);
    }
}
