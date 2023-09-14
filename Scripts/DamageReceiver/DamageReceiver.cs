using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class DamageReceiver : AutoMonoBehaviour
{
    protected const int DEFAULT_MAXIMUM_HEALTH = 100;

    [Header("The Object's currentHealth informations"), Space(10)]
    [SerializeField] protected int currentHealth = 0;
    public int CurrentHealth => this.currentHealth;

    [SerializeField] protected int maximumHealth = DEFAULT_MAXIMUM_HEALTH;
    [SerializeField] protected bool isDead = false;

    protected virtual void Update() => this.CheckDead();
    protected virtual void CheckDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void ResetHealthToMaximum() =>
        (this.isDead, this.currentHealth) = (false, this.maximumHealth);

    public virtual void IncreaseHealth(int health) =>
        this.currentHealth = Mathf.Min(this.maximumHealth, this.currentHealth + health);

    public virtual void DecreaseHealth(int health) =>
        this.currentHealth = Mathf.Max(0, this.currentHealth - health);

    protected abstract void OnDead();
    protected virtual bool IsDead() => this.currentHealth <= 0;
}