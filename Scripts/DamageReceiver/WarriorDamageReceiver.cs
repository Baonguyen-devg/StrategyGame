using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDamageReceiver : BaseDamageReceiver
{
    protected override void OnDead() => WarriorSpawner.Instance.Despawn(transform.parent);
}
