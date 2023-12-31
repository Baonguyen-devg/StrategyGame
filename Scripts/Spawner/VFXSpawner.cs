using UnityEngine;

public class VFXSpawner : Spawner<string>
{
    private static VFXSpawner instance;
    public static VFXSpawner Instance => instance;

    protected override bool CompareType(Transform p, string type) =>
        p.name.Equals(type);

    protected override void Awake()
    {
        base.Awake();
        VFXSpawner.instance = this;
    }
}
