using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TitleImpact : AutoMonoBehaviour
{
    [SerializeField] private Transform model = default;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => this.model ??= transform.Find("Model");

    private void OnMouseEnter() 
    {
        GameController.Instance.SetTitleChoosing(transform);
        this.model.gameObject.SetActive(true);
    }

    private void OnMouseExit() 
    {
        GameController.Instance.SetTitleChoosing(null);
        this.model.gameObject.SetActive(false);
    }

    private void OnMouseUp() 
    {
        if (GameController.Instance.TitleChoosing == null) return;
        if (GameController.Instance.ButtonStoreWarrior == null) return;

        GameController.Instance.ButtonStoreWarrior.BuyWarrior();
        GameController.Instance.SetTypeWarriorChoosing(null);

        gameObject.SetActive(false);
        GameController.Instance.Tiles.gameObject.SetActive(false);
    }
}
