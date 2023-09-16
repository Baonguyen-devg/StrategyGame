using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateWarriorGroup : AutoMonoBehaviour
{
    private static CreateWarriorGroup instance;
    public static CreateWarriorGroup Instance => instance;

    private Dictionary<string, ISpawnWarriorFactory> spawnWarriorFactories
        = new Dictionary<string, ISpawnWarriorFactory>();

    protected override void Awake()
    {
        base.Awake();
        CreateWarriorGroup.instance = this;
        var factoryPrefabs = transform.Find("Warrior_Factories").Cast<Transform>();

        foreach (var factoryPref in factoryPrefabs)
            this.spawnWarriorFactories.Add(factoryPref.name, factoryPref.GetComponent<ISpawnWarriorFactory>());
    }

    private ISpawnWarriorFactory GetFactoryByName(string name) =>
        this.spawnWarriorFactories.TryGetValue(name, out var fac) ? fac : null;

    public virtual void RequestCreateWarriors() =>
        this.SpawnGroupEnemy(GameController.Instance.TypeWarriorChoosing);

    private void SpawnGroupEnemy(string name)
    {
        Transform point = GameController.Instance.TitleChoosing;
        Transform groupSpawn = GroupSpawner.Instance.Spawn("Group_Warrior", point.position, point.rotation);
        var factoy = this.GetFactoryByName(name);

        var listPointWarrior = groupSpawn.Cast<Transform>();
        foreach (Transform pointSpawn in listPointWarrior)
            factoy.SpawnMechanism(pointSpawn.position, pointSpawn.rotation);
    }
}
