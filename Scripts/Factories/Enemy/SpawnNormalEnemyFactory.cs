using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormalEnemyFactory : AutoMonoBehaviour, ISpawnEnemyFactory
{
    [SerializeField] private NormalEnemy enemyProduct;
    public IEnemyProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        Transform enemy = EnemySpawner.Instance.Spawn(this.enemyProduct.name, pos, rot);
        return enemy.GetComponent<IEnemyProduct>();
    }
}
