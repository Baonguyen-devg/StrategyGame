using UniRx;
using UnityEngine;

public abstract class BaseMovement : BaseLoadConfigData<MovementSO>
{
    protected const float DEFAULT_SPEED = 1f;
    protected const float DEFAULT_MAXIMUM_SPEED = 10;
    protected const float DEFAULT_MINIMUM_SPEED = 0.01f;

    #region Variables
    [Header("[ Base move behaviour ]"), Space(5)]
    [SerializeField] protected float speed = DEFAULT_SPEED;
    [SerializeField] protected float maximumSpeed = DEFAULT_MAXIMUM_SPEED;
    [SerializeField] protected float minimumSpeed = DEFAULT_MINIMUM_SPEED;

    [SerializeField] protected bool isMovingFast = false;
    //private CompositeDisposable disposables = new CompositeDisposable();
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.SetNameConfig("Movement");
        base.LoadComponent();
       
        this.speed = this.dataSO.GetSpeed();
        this.maximumSpeed = this.dataSO.GetMaximumSpeed();
        this.minimumSpeed = this.dataSO.GetMinimumSpeed();
    }
    #endregion

    #region Main methods
    protected override void Start() =>
        Observable.EveryUpdate()
                  .Where(_ => transform.gameObject.activeSelf && Time.timeScale == 1)
                  .Subscribe(_ => this.Move()).AddTo(this);

    public virtual void IncreaseSpeed(float speed) =>
        this.speed = Mathf.Min(this.maximumSpeed, this.speed + speed);

    public virtual void DecreaseSpeed(float speed) =>
        this.speed = Mathf.Max(this.minimumSpeed, this.speed - speed);

    protected abstract void Move();
    #endregion
}