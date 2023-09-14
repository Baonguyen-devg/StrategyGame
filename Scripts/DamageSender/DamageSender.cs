using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : AutoMonoBehaviour
{
    protected const int DEFAULT_MAXIMUM_DAMAGE = 100;

    [Header("Object's damage sender"), Space(10)]
    [SerializeField] protected int dame = 0;
    [SerializeField] protected int maximumDame = DEFAULT_MAXIMUM_DAMAGE;

    public virtual void IncreaseDame(int dame) =>
        this.dame = Mathf.Min(this.dame + dame, this.maximumDame);

    public virtual void DecreaseDame(int dame) =>
        this.dame = Mathf.Max(this.dame - dame, 0);

    public abstract void Send(Transform obj);
}