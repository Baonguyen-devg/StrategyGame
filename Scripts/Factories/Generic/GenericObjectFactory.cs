using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectFactory<T, Pooling> : AutoMonoBehaviour, IFactory
    where T : IProduct where Pooling : Spawner<string> 
{
    [Header("[ Factory's Information ]"), Space(6)]
    [SerializeField] protected T objectProduct;
    [SerializeField] protected Pooling poolingSpawner;

    public IProduct SpawnMechanism(Vector3 pos, Quaternion rot) 
    {
        if (poolingSpawner is not Spawner<string>) 
        {
            Debug.LogError(poolingSpawner.name + " is not a pooling class");
            return null;
        }
        Transform product = poolingSpawner.Spawn(objectProduct.name, pos, rot);
        return product.GetComponent<T>();
    }
}
