public class HealthSystem
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public HealthSystem(int health, int maxHealth)
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
