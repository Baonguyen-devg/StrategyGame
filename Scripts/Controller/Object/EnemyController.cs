using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AutoMonoBehaviour
{
    [Header("Component Enemy"), Space(6)]
    [SerializeField] private Transform model;
    [SerializeField] private EnemyDamageReceiver enemyDamageReceiver;
    [SerializeField] private EnemyDamgeSender enemyDamgeSender;
    [SerializeField] private EnemyImpact enemyImpact;
    [SerializeField] private EnemyMovement enemyMovement;

    public virtual Transform GetModel() => this.model;

    public virtual EnemyDamageReceiver GetEnemyDamageReceiver() => this.enemyDamageReceiver;

    public virtual EnemyDamgeSender GetEnemyDamgeSender() => this.enemyDamgeSender;

    public virtual EnemyImpact GetEnemyImpact() => this.enemyImpact;

    public virtual EnemyMovement GetEnemyMovement() => this.enemyMovement;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.model = transform.Find("Model");
        this.enemyImpact = GetComponentInChildren<EnemyImpact>();
        this.enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        this.enemyDamgeSender = GetComponentInChildren<EnemyDamgeSender>();
        this.enemyMovement = GetComponentInChildren<EnemyMovement>();
    }
}
