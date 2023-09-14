using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : AutoMonoBehaviour
{
    private const float DEFAULT_RATE_TIME_COUNTDOWN = 4f;
    private const string DEFAULT_NAME_FACTORY_PRESENT = "Small_Enemy_Factory";

    private event System.EventHandler LevelGenerateEvent;
    [SerializeField] private List<Transform> points = new List<Transform>();

    [SerializeField]
    private Dictionary<string, ISpawnEnemyFactory> spawnEnemyFactories
        = new Dictionary<string, ISpawnEnemyFactory>();

    [Header("[ Level Generation ]"), Space(6)]
    [SerializeField] private string nameFactoryPresent = DEFAULT_NAME_FACTORY_PRESENT;

    [SerializeField] private float countDown = DEFAULT_RATE_TIME_COUNTDOWN;
    [SerializeField] private float rateTimeCountDown = DEFAULT_RATE_TIME_COUNTDOWN;

    protected override void LoadComponent()
    {
        if (this.points.Count != 0) this.points.Clear();
        this.points.AddRange(transform.Find("Spawn_Enemy_Points").Cast<Transform>());
    }

    protected override void Awake()
    {
        base.Awake();
        this.LevelGenerateEvent += this.SpawnGroupEnemy;
        var factoryPrefabs = transform.Find("Enemy_Factories").Cast<Transform>();

        foreach (var factoryPref in factoryPrefabs)
            this.spawnEnemyFactories.Add(factoryPref.name, factoryPref.GetComponent<ISpawnEnemyFactory>());
    }

    private void Update()
    {
        this.countDown = this.countDown - Time.deltaTime;
        if (this.countDown >= 0) return;
        this.LevelGenerateEvent?.Invoke(null, System.EventArgs.Empty);
        this.countDown = rateTimeCountDown;
    }

    private Transform GetRandomPoint() => this.points[Random.Range(0, this.points.Count)];

    private ISpawnEnemyFactory GetFactoryByName(string name) =>
        this.spawnEnemyFactories.TryGetValue(name, out var fac) ? fac : null;

    private void SpawnGroupEnemy(object sender, System.EventArgs e)
    {
        Transform point = this.GetRandomPoint();
        Transform groupSpawn = GroupSpawner.Instance.Spawn("Group_Enemy", point.position, point.rotation);
        var factoy = this.GetFactoryByName(this.nameFactoryPresent);
 
        var listPointEnemy = groupSpawn.Cast<Transform>();
        foreach (Transform pointSpawn in listPointEnemy)
            factoy.SpawnMechanism(pointSpawn.position, pointSpawn.rotation);
    }
}
