using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;

public class EnemyMovement : BaseMovement
{
    private const float DEFAULT_DISTANCE_STOP = 0.2f;
    private readonly string TRIGGER_NAME = "Attack";
    private readonly string HORIZONTAL_NAME = "Horizontal";
    private readonly string VERTICAL_NAME = "Vertical";

    #region Variables
    [SerializeField] private float distanceStop = DEFAULT_DISTANCE_STOP;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform tower;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.tower = GameObject.Find("Tower").transform;
        this.animator = transform.parent.Find("Model").GetComponent<Animator>();
    }
    #endregion

    #region Main methods
    private void OnEnable() => this.animator.SetBool(TRIGGER_NAME, false);

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
    ) {
        Vector3 direction = obj.position - this.transform.parent.position;
        direction.Normalize();
        this.animator.SetFloat(HORIZONTAL_NAME, direction.x);
        this.animator.SetFloat(VERTICAL_NAME, direction.y);
    }
    #endregion
}