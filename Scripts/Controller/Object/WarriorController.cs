using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : AutoMonoBehaviour
{
    [SerializeField] private WarriorDamageReceiver warriorDamageReceiver;

    public WarriorDamageReceiver WarriorDamageReceiver => this.warriorDamageReceiver;
}
