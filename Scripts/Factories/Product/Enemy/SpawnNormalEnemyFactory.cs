using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormalEnemyFactory : GenericObjectFactory<NormalEnemy, EnemySpawner> 
{
    protected override void Start() => this.poolingSpawner = EnemySpawner.Instance;
}
