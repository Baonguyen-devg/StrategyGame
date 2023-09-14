using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemyFactory : AutoMonoBehaviour, ISpawnEnemyFactory
{
    [SerializeField] private Dictionary<string, IEnemyProduct> products;

    protected override void Awake()
    {
        base.Awake();
        this.products = new Dictionary<string, IEnemyProduct>()
        {
            { "SmallEnemy", new SmallEnemy() },
            { "NormalEnemy", new NormalEnemy() },
            { "BigEnemy", new BigEnemy() }
        };
    }

    public IEnemyProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        return null;
    }
}
