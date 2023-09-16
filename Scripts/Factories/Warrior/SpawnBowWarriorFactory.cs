using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowWarriorFactory : AutoMonoBehaviour, ISpawnWarriorFactory
{
    [SerializeField] private BowWarrior warriorProduct;
    public IWarriorProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        Transform warrior = WarriorSpawner.Instance.Spawn(this.warriorProduct.name, pos, rot);
        return warrior.GetComponent<IWarriorProduct>();
    }
}
