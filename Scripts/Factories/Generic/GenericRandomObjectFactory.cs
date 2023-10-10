using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericRandomObjectFactory<T, Pooling> : AutoMonoBehaviour, IFactory
    where T : IProduct where Pooling: Spawner<string> 
{
    [Header("[ Factory's Information ]"), Space(6)]
    protected Dictionary<string, T> products = new Dictionary<string, T>();
    [SerializeField] protected Pooling poolingSpawner;

    protected override void Awake() 
    {
        base.Awake();
        var prefabs = transform.parent.parent.Find("Prefabs").Cast<Transform>();
        foreach (Transform prefab in prefabs)
        {
            T objectT = prefab.GetComponent<T>();
            this.products.Add(prefab.name, objectT);
        }
    }

    public IProduct SpawnMechanism(
        Vector3 pos,
        Quaternion rot
    ) {
        int keyRandom = Random.Range(0, this.products.Count);
        string nameObject = this.products.ElementAt(keyRandom).Key;
        if (poolingSpawner is not Spawner<string>) 
        {
            Debug.LogError(poolingSpawner.name + " is not a pooling class");
            return null;
        }
        Transform obj = poolingSpawner.Spawn(nameObject, pos, rot);
        return obj.GetComponent<T>();
    }
}
