using UnityEngine;

public class EnemySpawner : Spawner<string>
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override bool CompareType(Transform p, string type) =>
        p.name.Equals(type);

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }
}

