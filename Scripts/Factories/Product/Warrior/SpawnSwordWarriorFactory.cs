using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwordWarriorFactory : GenericObjectFactory<SwordWarrior, WarriorSpawner> 
{
    protected override void Start() => this.poolingSpawner = WarriorSpawner.Instance;
}
