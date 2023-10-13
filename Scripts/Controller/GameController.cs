using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AutoMonoBehaviour
{
    private const int DEFAULT_MONEY_NUMBER = 1000;
    private const int DEFAULT_MAX_MONEY_NUMBER = 1000;

    private static GameController instance;
    public static GameController Instance => instance;

    public event System.EventHandler MoneyEvent;

    #region Variables 

    [Header("[ Game Informations ]"), Space(6)]
    [SerializeField] private int moneyNumber = DEFAULT_MONEY_NUMBER;
    [SerializeField] private int maxMoneyNumber = DEFAULT_MAX_MONEY_NUMBER;

    [SerializeField] private Transform tiles;
    [SerializeField] private Transform titleChoosing;
    [SerializeField] private ButtonStoreWarrior buttonStoreWarrior;

    #endregion

    public int MoneyNumber => this.moneyNumber;
    public Transform Tiles => this.tiles;
    public Transform TitleChoosing => this.titleChoosing;
    public ButtonStoreWarrior ButtonStoreWarrior => this.buttonStoreWarrior;

    #region Load component methods;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() => 
        this.tiles = GameObject.Find("Tiles").transform;

    #endregion

    #region Main methods

    protected override void Awake()
    {
        base.Awake();
        GameController.instance = this;
        this.tiles.gameObject.SetActive(false);
    }

    public virtual void IncreaseMoney(
        int number
    ) {
        int newMoney = this.moneyNumber + number;
        this.moneyNumber = Mathf.Min(this.maxMoneyNumber, newMoney);
        this.MoneyEvent?.Invoke(this, System.EventArgs.Empty);
    }

    public virtual void DecreaseMoney(
        int number
    ) {
        int newMoney = this.moneyNumber - number;
        this.moneyNumber = Mathf.Max(0, newMoney);
        this.MoneyEvent?.Invoke(this, System.EventArgs.Empty);
    }

    public virtual void SetTitleChoosing(
       Transform title
   ) => this.titleChoosing = title;

    public virtual void SetTypeWarriorChoosing(
        ButtonStoreWarrior type
    ) => this.buttonStoreWarrior = type;

    #endregion
}
