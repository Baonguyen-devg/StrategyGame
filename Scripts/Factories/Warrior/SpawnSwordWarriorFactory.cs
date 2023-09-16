using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwordWarriorFactory : AutoMonoBehaviour, ISpawnWarriorFactory
{
    [SerializeField] private SwordWarrior warriorProduct;
    public IWarriorProduct SpawnMechanism(Vector3 pos, Quaternion rot)
    {
        Transform warrior = WarriorSpawner.Instance.Spawn(this.warriorProduct.name, pos, rot);
        return warrior.GetComponent<IWarriorProduct>();
    }
}
