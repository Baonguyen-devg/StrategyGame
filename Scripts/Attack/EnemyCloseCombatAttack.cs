using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyCloseCombatAttack : AutoMonoBehaviour
{
    private const float DEFAULT_RADIUX = 0.1f;
    private readonly string TRIGGER_NAME = "Attack";

    [Header("[ Component get from asset, don't load in load methods ]"), Space(6)]
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private LayerMask layerMask;

    #region Variables
    [Header("[ Componet ]"), Space(6)]
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private float radiux = DEFAULT_RADIUX;
    [SerializeField] private Animator animator;
    [SerializeField] private float rateTimeTakeDame;
    #endregion

    #region Load component methods
    [ContextMenu("Load component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        this.animator = this.enemyController.GetModel().GetComponent<Animator>();
        this.rateTimeTakeDame = animationClip.length;
    }
    #endregion

    #region Main methods
    protected override void Start() =>
        Observable.Interval(System.TimeSpan.FromSeconds(this.rateTimeTakeDame))
                  .Where(_ => gameObject.activeSelf)
                  .Subscribe(_ =>
                  {
                      var warrior = this.HaveWarriorInRegion();
                      if (warrior == null) return;
                      this.enemyController.GetEnemyDamgeSender().Send(warrior);
                  }).AddTo(this);

    private Transform HaveWarriorInRegion() =>
        Physics2D.OverlapCircle(transform.position, this.radiux, this.layerMask).transform;

    private void OnEnable() => this.animator.SetBool(TRIGGER_NAME, true);

    private void OnDisable() => this.animator.SetBool(TRIGGER_NAME, false);
    #endregion
}
