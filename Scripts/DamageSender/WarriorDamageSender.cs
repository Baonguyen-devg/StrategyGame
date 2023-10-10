using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDamageSender : BaseDamageSender
{
    public override void Send(Transform obj)
    {
        EnemyDamageReceiver enemyDamageReceiver;
        enemyDamageReceiver = obj.GetComponent<EnemyDamageReceiver>();
        enemyDamageReceiver?.DecreaseHealth(this.dame);
    }
}
