using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSpawner : Spawner<string>
{
    private static GroupSpawner instance;
    public static GroupSpawner Instance => instance;

    protected override bool CompareType(Transform p, string type) =>
        p.name.Equals(type);

    protected override void Awake()
    {
        base.Awake();
        GroupSpawner.instance = this;
    }
}
