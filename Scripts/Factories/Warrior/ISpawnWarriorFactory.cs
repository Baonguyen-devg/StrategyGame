using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnWarriorFactory
{
    public abstract IWarriorProduct SpawnMechanism(Vector3 pos, Quaternion rot);
}
