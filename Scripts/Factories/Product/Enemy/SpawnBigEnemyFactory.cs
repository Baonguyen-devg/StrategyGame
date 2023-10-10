using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigEnemyFactory : GenericObjectFactory<BigEnemy, EnemySpawner> 
{
    protected override void Start() => this.poolingSpawner = EnemySpawner.Instance;
}
