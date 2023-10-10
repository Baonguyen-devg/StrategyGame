using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : BaseImpact
{
    [SerializeField] private EnemyController enemyController;

    [ContextMenu("Load Componet")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemyController = transform.parent.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var warriorReceiver = collision.GetComponent<WarriorDamageReceiver>();
        if (warriorReceiver == null) return;
        this.enemyController.GetEnemyDamgeSender().Send(collision.transform);
    }
}
