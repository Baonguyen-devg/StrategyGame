using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamageSender : BaseLoadConfigData<DamageSenderSO>
{
    protected const int DEFAULT_MAXIMUM_DAMAGE = 100;

    #region Variables
    [Header("[ Base damage sender ]"), Space(10)]
    [SerializeField] protected int maximumDame = DEFAULT_MAXIMUM_DAMAGE;
    [SerializeField] protected int dame = 0;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.SetNameConfig("Damage Sender");
        base.LoadComponent();

        this.dame = this.dataSO.GetDame();
        this.maximumDame = this.dataSO.GetMaximumDame();
    }
    #endregion

    #region Main methods
    public virtual void IncreaseDame(int dame)
    {
        int newDame = this.dame + dame;
        this.dame = Mathf.Min(newDame, this.maximumDame);
    }

    public virtual void DecreaseDame(int dame)
    {
        int newDame = this.dame - dame;
        this.dame = Mathf.Max(newDame, 0);
    }

    public abstract void Send(Transform obj);
    #endregion
}