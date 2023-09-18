using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private const int DEFAULT_MONEY_NUMBER = 1000;
    private const int DEFAULT_MAX_MONEY_NUMBER = 1000;

    private static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] private int moneyNumber = DEFAULT_MONEY_NUMBER;
    [SerializeField] private int maxMoneyNumber = DEFAULT_MAX_MONEY_NUMBER;

    [SerializeField] private Transform tiles;
    [SerializeField] private Transform titleChoosing;
    [SerializeField] private ButtonStoreWarrior buttonStoreWarrior;

    public event System.EventHandler MoneyEvent;

    public int MoneyNumber => this.moneyNumber;
    public Transform Tiles => this.tiles;
    public Transform TitleChoosing => this.titleChoosing;
    public ButtonStoreWarrior ButtonStoreWarrior => this.buttonStoreWarrior;

    public virtual void SetTitleChoosing(Transform title) => this.titleChoosing = title;
    public virtual void SetTypeWarriorChoosing(ButtonStoreWarrior type) => this.buttonStoreWarrior = type;

    public virtual void IncreaseMoney(int number)
    {
        this.moneyNumber = Mathf.Min(this.maxMoneyNumber, this.moneyNumber + number);
        this.MoneyEvent?.Invoke(this, System.EventArgs.Empty);
    }

    public virtual void DecreaseMoney(int number)
    {
        this.moneyNumber = Mathf.Max(0, this.moneyNumber - number);
        this.MoneyEvent?.Invoke(this, System.EventArgs.Empty);
    }

    protected override void LoadComponent() => this.tiles = GameObject.Find("Tiles").transform;
    protected override void Awake()
    {
        base.Awake();
        GameController.instance = this;
    }

    protected override void Start() =>
         this.tiles.gameObject.SetActive(false);
}
