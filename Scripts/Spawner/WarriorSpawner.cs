using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WarriorSpawner : Spawner<string>
{
    private static WarriorSpawner instance;
    public static WarriorSpawner Instance => instance;

    public List<Transform> factories;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (this.factories.Count != 0) this.factories.Clear();
        this.factories.AddRange(transform.Find("Factories").Cast<Transform>());
    }

    public virtual IFactory FindFactoryByName(string name)
    {
        foreach (Transform factory in this.factories)
            if (factory.name.Equals(name)) return factory.GetComponent<IFactory>();
        return null;
    }

    protected override bool CompareType(Transform p, string type) =>
        p.name.Equals(type);

    protected override void Awake()
    {
        base.Awake();
        WarriorSpawner.instance = this;
    }
}
