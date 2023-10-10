using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRandomWarriorFactory : GenericRandomObjectFactory<IWarriorProduct, WarriorSpawner> 
{
    protected override void Start() => this.poolingSpawner = WarriorSpawner.Instance;
}
