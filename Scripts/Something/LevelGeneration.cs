using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : AutoMonoBehaviour
{
    private const float DEFAULT_RATE_TIME_COUNTDOWN = 2f;

    private event System.EventHandler LevelGenerateEvent;
    [SerializeField] private List<Transform> points = new List<Transform>();

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
        this.LevelGenerateEvent += this.SpawnEnemyGroup;
    }

    private void Update()
    {
        this.countDown = this.countDown - Time.deltaTime;
        if (this.countDown >= 0) return;

        this.LevelGenerateEvent?.Invoke(null, System.EventArgs.Empty);
        this.countDown = rateTimeCountDown;
    }

    private Transform GetRandomPoint() => this.points[Random.Range(0, this.points.Count)];
    private void SpawnEnemyGroup(object sender, System.EventArgs e)
    {
        Transform point = this.GetRandomPoint();

    }
}
