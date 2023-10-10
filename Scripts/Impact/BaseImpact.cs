using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BaseImpact : AutoMonoBehaviour
{
    [Header("[ Components For Impact ]"), Space(5)]
    [SerializeField] protected Rigidbody2D rigid2D;
    [SerializeField] protected Collider2D colli2D;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.colli2D = GetComponent<Collider2D>();
    }
}
