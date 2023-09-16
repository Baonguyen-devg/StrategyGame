using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRandomWarriorFactory : AutoMonoBehaviour, ISpawnWarriorFactory
{
    [SerializeField] 
    private Dictionary<string, IWarriorProduct> products 
        = new Dictionary<string, IWarriorProduct>();

    protected override void Awake()
    {
        base.Awake();
        var prefabs = transform.Find("Prefabs").Cast<Transform>();
        foreach (Transform prefab in prefabs)
            this.products.Add(prefab.name, prefab.GetComponent<IWarriorProduct>());
    }

    public IWarriorProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        string nameWarrior = this.products.ElementAt(Random.Range(0, this.products.Count)).Key;
        Transform warrior = WarriorSpawner.Instance.Spawn(nameWarrior, pos, rot);
        return warrior.GetComponent<IWarriorProduct>();
    }
}
