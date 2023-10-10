using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyStateBehaviour : AutoMonoBehaviour
{
    [TextArea(2, 10), Space(6)]
    [SerializeField] private string DeveloperDescriber = "";

    [Header("[ Load Component ]"), Space(6)]
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private StateBehaviour stateBehaviour = StateBehaviour.none;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius = 1f;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.enemyController = GetComponent<EnemyController>();
    }

    protected override void Start()
    {
        this.SetStateMoving();
        Observable.EveryUpdate().Subscribe(_ => 
        {
            this.HaveWarrior();
            this.CheckState();
        });
    }

    private void HaveWarrior()
    {
        Collider2D warrior = Physics2D.OverlapCircle(transform.position, this.radius, this.layerMask);
        if (warrior != null) this.SetStateAttack();
        else this.SetStateMoving();
    }

    private void CheckState()
    {
        switch(this.stateBehaviour)
        {
            case StateBehaviour.moving:
                this.MovingBehaviour();
                break;

            case StateBehaviour.attack:
                this.AttackBehaviour();
                break;

            case StateBehaviour.die:
                this.DieBehaviour();
                break;

            case StateBehaviour.none:
                break;

            default:
                break;
        }
    }

    private void MovingBehaviour()
    {
        this.enemyController.GetEnemyMovement().gameObject.SetActive(true);
        this.stateBehaviour = StateBehaviour.none;
    }

    private void AttackBehaviour()
    {
        this.enemyController.GetEnemyMovement().gameObject.SetActive(false);
        this.enemyController.GetEnemyImpact().gameObject.SetActive(true);
        this.stateBehaviour = StateBehaviour.none;
    }

    private void DieBehaviour()
    {
        this.stateBehaviour = StateBehaviour.none;
    }

    public virtual void SetStateMoving() => this.stateBehaviour = StateBehaviour.moving;

    public virtual void SetStateAttack() => this.stateBehaviour = StateBehaviour.attack;

    public virtual void SetStateDie() => this.stateBehaviour = StateBehaviour.die;

    private enum StateBehaviour
    {
        moving, attack, die, none,
    }
}
