using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner<string>
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override bool CompareType(
        Transform p,
        string type
    ) => p.name.Equals(type);

    protected override void Awake() 
    {
        base.Awake();
        BulletSpawner.instance = this;
    }
}
