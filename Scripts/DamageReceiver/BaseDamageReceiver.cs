using UnityEngine;
using UniRx;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class BaseDamageReceiver : BaseLoadConfigData<DamageReceiverSO>
{
    protected const int DEFAULT_MAXIMUM_HEALTH = 100;

    #region Variables
    [Header("[ Base damage receiver ]"), Space(10)]
    [SerializeField] protected int currentHealth = DEFAULT_MAXIMUM_HEALTH;
    [SerializeField] protected int maximumHealth = DEFAULT_MAXIMUM_HEALTH;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected bool isDead = false;

    public int CurrentHealth => this.currentHealth;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.SetNameConfig("Damage Receiver");
        base.LoadComponent();

        this.boxCollider2D = GetComponent<BoxCollider2D>();  
        this.currentHealth = this.dataSO.GetCurrentHealth();
        this.maximumHealth = this.dataSO.GetMaximumHealth();
    }
    #endregion

    #region Main methods
    protected override void Start() =>
        Observable.EveryUpdate().Where(_ => this.IsDead())
                  .Subscribe(_ =>
                  {
                      this.SetDead(true);
                      this.OnDead();
                  }).AddTo(this);

    protected virtual void ResetHealthToMaximum() =>
        (this.isDead, this.currentHealth) = (false, this.maximumHealth);

    public virtual void IncreaseHealth(int health) =>
        this.currentHealth = Mathf.Min(this.maximumHealth, this.currentHealth + health);

    public virtual void DecreaseHealth(int health) =>
        this.currentHealth = Mathf.Max(0, this.currentHealth - health);

    protected virtual bool IsDead() => this.currentHealth <= 0;

    protected virtual void SetDead(bool status) => this.isDead = status;

    protected abstract void OnDead();
    #endregion
}