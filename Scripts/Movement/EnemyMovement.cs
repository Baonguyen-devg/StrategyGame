using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    private const float DEFAULT_DISTANCE_STOP = 0.2f;

    [SerializeField] private float distanceStop = DEFAULT_DISTANCE_STOP;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform tower;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.tower = GameObject.Find("Tower").transform;
        this.animator = transform.parent.Find("Model").GetComponent<Animator>();
    }

    private void OnEnable() => this.animator.SetBool("Attack", false);

    protected override void Move()
    {
        this.LookToObject(this.tower);
        float distance = Vector3.Distance(transform.parent.position, this.tower.position);
        if (distance <= this.distanceStop) return;

        Vector3 direction = this.tower.position - this.transform.parent.position;
        direction.Normalize();
        Vector3 newPostion = transform.parent.position + direction;
        transform.parent.position = Vector3.Lerp(transform.parent.position, newPostion, this.speed);
    }

    private void LookToObject(
        Transform obj
    )
    {
        Vector3 direction = obj.position - this.transform.parent.position;
        direction.Normalize();
        this.animator.SetFloat("Horizontal", direction.x);
        this.animator.SetFloat("Vertical", direction.y);
    }
}