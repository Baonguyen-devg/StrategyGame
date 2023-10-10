using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowWarriorFactory : GenericObjectFactory<BowWarrior, WarriorSpawner> 
{
    protected override void Start() => this.poolingSpawner = WarriorSpawner.Instance;
}
