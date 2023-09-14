using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : Spawner<string>
{
    private static WarriorSpawner instance;
    public static WarriorSpawner Instance => instance;

    protected override bool CompareType(Transform p, string type) =>
        p.name.Equals(type);

    protected override void Awake()
    {
        base.Awake();
        WarriorSpawner.instance = this;
    }
}
