using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    private const float DEFAULT_DISTANCE_STOP = 1f;

    [SerializeField] private float distanceStop = DEFAULT_DISTANCE_STOP;
    [SerializeField] private Transform tower;

    protected override void LoadComponent() =>
        this.tower = GameObject.Find("Tower").transform;

    protected override void Move()
    {
        if (Vector3.Distance(transform.parent.position, this.tower.position) 
            <= this.distanceStop) return;

        Vector3 direction = this.tower.position - this.transform.parent.position;
        direction.Normalize();
        Vector3 newPostion = transform.parent.position + direction;
        transform.parent.position = Vector3.Lerp(transform.parent.position, newPostion, this.speed);
    }
}
