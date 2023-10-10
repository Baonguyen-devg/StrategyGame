using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : BaseDamageReceiver
{
    protected override void OnDead() => EnemySpawner.Instance.Despawn(transform.parent);
}
