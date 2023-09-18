using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStoreWarrior : AutoMonoBehaviour
{
    private const float DEFAULT_RATE_TIME_COUNTDOWN = 2f;
    private const bool DEFAULT_CAN_BUY = false;
    private const int DEFAULT_MONEY = 100;
    private const string DEFAULT_NAME_FACTORY = "Sword_Warrior_Factory";

    [SerializeField] private Image shapeCountDown;
    [SerializeField] private float timeCountDown = DEFAULT_RATE_TIME_COUNTDOWN;
    [SerializeField] private float rateTimeCountDown = DEFAULT_RATE_TIME_COUNTDOWN;
    [SerializeField] private Transform tiles; 

    [SerializeField] private int money = DEFAULT_MONEY;
    [SerializeField] private bool canBuy = DEFAULT_CAN_BUY;
    [SerializeField] private string nameFactory = DEFAULT_NAME_FACTORY;

    public string NameFactory => this.nameFactory;

    protected override void LoadComponent()
    {
        this.shapeCountDown = transform.Find("Shape_CountDown").GetComponent<Image>();
        this.tiles = GameObject.Find("Tiles").transform;
    }

    private void Update()
    {
        if (this.canBuy) return;

        this.timeCountDown = this.timeCountDown - Time.deltaTime;
        this.shapeCountDown.fillAmount = (float)this.timeCountDown / this.rateTimeCountDown;

        if (this.timeCountDown > 0) return;
        this.canBuy = true;
        (this.timeCountDown, this.shapeCountDown.fillAmount) = (this.rateTimeCountDown, 1);
        this.shapeCountDown.gameObject.SetActive(false);
    }

    public virtual void PressButton(string nameFactoyWarrior)
    {
        if (!this.canBuy) return;
        if (this.money > GameController.Instance.MoneyNumber) return;
        GameController.Instance.SetTypeWarriorChoosing(this);
        this.tiles.gameObject.SetActive(true);
    }

    public virtual void BuyWarrior()
    {
        this.canBuy = false;
        this.shapeCountDown.gameObject.SetActive(true);

        GameController.Instance.DecreaseMoney(this.money);
        CreateWarriorGroup.Instance.RequestCreateWarriors();
    }
}
