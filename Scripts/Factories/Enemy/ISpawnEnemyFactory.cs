using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnEnemyFactory
{
    public abstract IEnemyProduct SpawnMechanism(Vector3 pos, Quaternion rot);
}
