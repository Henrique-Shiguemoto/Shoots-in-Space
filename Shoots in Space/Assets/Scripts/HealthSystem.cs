public class HealthSystem
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    //Constructor for the cases where a game object starts with health not equal to its max health
    public HealthSystem(int health, int maxHealth)
    {
        this.Health = maxHealth;
        this.MaxHealth = maxHealth;
    }

    //Constructor for the case where a game object starts with health equal to its max health
    public HealthSystem(int maxHealth)
    {
        this.Health = maxHealth;
        this.MaxHealth = maxHealth;
    }

    public void DealDamage(int damageDealt)
    {
        Health -= damageDealt;
        if(Health <= 0){
            Health = 0;
        }
    }

    public void Heal(int healAmount)
    {
        this.Health += healAmount;
        if(Health >= MaxHealth){
            Health = MaxHealth;
        }
    }
}
