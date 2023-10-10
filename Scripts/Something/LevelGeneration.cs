using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class LevelGeneration : AutoMonoBehaviour
{
    private const float DEFAULT_RATE_TIME_COUNTDOWN = 4f;
    private const float DEFAULT_RATE_TIME_CHANGE_FACTORY = 30f;
    private const string DEFAULT_NAME_FACTORY_PRESENT = "Small_Enemy_Factory";

    private event System.EventHandler LevelGenerateEvent;
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private List<Transform> processSpawn = new List<Transform>();

    [Header("[ Level Generation ]"), Space(6)]
    [SerializeField] private float rateTimeCountDown = DEFAULT_RATE_TIME_COUNTDOWN;
    [SerializeField] private float rateTimeChangeFactory = DEFAULT_RATE_TIME_CHANGE_FACTORY;

    [SerializeField] private string nameFactoryPresent = DEFAULT_NAME_FACTORY_PRESENT;
    [SerializeField] private int countProcess = 0;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() 
    {
        if (this.points.Count != 0) this.points.Clear();
        if (this.processSpawn.Count != 0) this.processSpawn.Clear();
        this.points.AddRange(transform.Find("Spawn_Enemy_Points").Cast<Transform>());
        this.processSpawn.AddRange(transform.Find("Process").Cast<Transform>());
    }

    protected override void Awake()
    {
        base.Awake();
        this.CreateObservable_LevelGenerate();
        this.CreateObservable_ChangeFactory();
    }

    private void CreateObservable_LevelGenerate()
    {
        this.LevelGenerateEvent += this.SpawnGroupEnemy;
        var timeSpanCountDown = System.TimeSpan.FromSeconds(this.rateTimeCountDown);
        var countDownStream = Observable.Interval(timeSpanCountDown).
            Subscribe(_ => this.LevelGenerateEvent?.Invoke(null, System.EventArgs.Empty));
    }

    private void CreateObservable_ChangeFactory()
    {
        var timeSpanChangeFactory = System.TimeSpan.FromSeconds(this.rateTimeChangeFactory);
        var changeFactoryStream = Observable.Interval(timeSpanChangeFactory).
            Subscribe(_ =>
            {
                this.countProcess = Mathf.Min(this.countProcess + 1, this.processSpawn.Count() - 1);
                this.nameFactoryPresent = this.processSpawn[this.countProcess].name;
            });
    }

    private Transform GetRandomPoint() => this.points[Random.Range(0, this.points.Count)];

    private IFactory GetFactoryByName(
        string name
    ) => EnemySpawner.Instance.FindFactoryByName(name);

    private void SpawnGroupEnemy(
        object sender, 
        System.EventArgs e
    ) {
        Transform point = this.GetRandomPoint();
        Transform groupSpawn = GroupSpawner.Instance.Spawn("Group_Enemy", point.position, point.rotation);
        var factoy = this.GetFactoryByName(this.nameFactoryPresent);
 
        var listPointEnemy = groupSpawn.Cast<Transform>();
        foreach (Transform pointSpawn in listPointEnemy)
            factoy.SpawnMechanism(pointSpawn.position, pointSpawn.rotation);
    }
}
