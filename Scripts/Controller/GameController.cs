using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private const int DEFAULT_COIN_NUMBER = 100;
    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] private int coinsNumber = DEFAULT_COIN_NUMBER;

    [SerializeField] private Transform titles;
    [SerializeField] private Transform titleChoosing;
    [SerializeField] private string typeWarriorChoosing;

    public Transform Titles => this.titles;
    public Transform TitleChoosing => this.titleChoosing;
    public string TypeWarriorChoosing => this.typeWarriorChoosing;

    public virtual void SetTitleChoosing(Transform title) => this.titleChoosing = title;
    public virtual void SetTypeWarriorChoosing(string type) => this.typeWarriorChoosing = type;

    //protected override void LoadComponent() => this.titles = GameObject.Find("Titles").transform;
    protected override void Awake()
    {
        base.Awake();
        GameController.instance = this;
    }
}
