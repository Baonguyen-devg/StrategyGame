using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRandomEnemyFactory : AutoMonoBehaviour, ISpawnEnemyFactory
{
    [SerializeField]
    private Dictionary<string, IEnemyProduct> products
        = new Dictionary<string, IEnemyProduct>();

    protected override void Awake()
    {
        base.Awake();
        var prefabs = transform.Find("Prefabs").Cast<Transform>();
        foreach (Transform prefab in prefabs)
            this.products.Add(prefab.name, prefab.GetComponent<IEnemyProduct>());
    }

    public IEnemyProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        string nameEnemy = this.products.ElementAt(Random.Range(0, this.products.Count)).Key;
        Transform enemy = EnemySpawner.Instance.Spawn(nameEnemy, pos, rot);
        return enemy.GetComponent<IEnemyProduct>();
    }
}
