using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmallEnemyFactory : GenericObjectFactory<SmallEnemy, EnemySpawner> 
{
    protected override void Start() => this.poolingSpawner = EnemySpawner.Instance;
}

