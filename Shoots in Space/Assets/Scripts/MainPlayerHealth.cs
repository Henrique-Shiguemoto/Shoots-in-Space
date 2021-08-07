using UnityEngine;
using TMPro;

public class MainPlayerHealth : MonoBehaviour
{
    //public variables
    public TextMeshProUGUI healthText;

    //private variables
    [SerializeField] private int maxMainPlayerHealth;
    [SerializeField] private Animator animator;
    private HealthSystem mainPlayerHealth;

    void Awake()
    {
        mainPlayerHealth = new HealthSystem(maxMainPlayerHealth); //Adding health system to Main Player
        healthText.text = "Health:" + mainPlayerHealth.MaxHealth.ToString(); //Setting health text to max health
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If player hits an enemy, it gets damaged and loses 1 health (hard coded for now)
        if(collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("EnemyShot")){
            FindObjectOfType<AudioManager>().PlaySound("SpaceShipHurt");
            mainPlayerHealth.DealDamage(1);
            healthText.text = "Health:" + mainPlayerHealth.Health.ToString();
            if(mainPlayerHealth.Health <= 0){
                animator.SetTrigger("TriggerExplosion"); //need to wait for the animation to destroy
                gameObject.GetComponent<Collider2D>().enabled = false;
                Invoke("Kill", 1.2f);
            }
        }
    }

    void Kill(){
        Destroy(gameObject);
    }
}
