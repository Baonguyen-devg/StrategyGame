using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamgeSender : BaseDamageSender
{
    public override void Send(Transform obj)
    {
        WarriorDamageReceiver warriorDamageReceiver;
        warriorDamageReceiver = obj.GetComponent<WarriorDamageReceiver>();
        warriorDamageReceiver?.DecreaseHealth(this.dame);
    }
}
