using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    public abstract IProduct SpawnMechanism(Vector3 pos, Quaternion rot);
}
