using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRandomEnemyFactory : GenericRandomObjectFactory<IWarriorProduct, EnemySpawner> 
{
    protected override void Start() => this.poolingSpawner = EnemySpawner.Instance;
}
