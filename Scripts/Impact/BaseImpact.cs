using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class BaseImpact : AutoMonoBehaviour
{
    #region Variables
    [Header("[ Components For Impact ]"), Space(5)]
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected Collider2D colli2D;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.colli2D = GetComponent<Collider2D>();
    }
    #endregion
}
