using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : AutoMonoBehaviour
{
    [SerializeField] private Text moneyText;

    [SerializeField] private Transform gamePanel;
    [SerializeField] private Transform loseGamePanel;
    [SerializeField] private Transform winGamePanel;
    [SerializeField] private Transform pauseGamePanel;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() 
    {
        this.gamePanel = transform.Find("Game_Panel");
        this.loseGamePanel = transform.Find("Lose_Game_Panel");
        this.winGamePanel = transform.Find("Win_Game_Panel");
        this.pauseGamePanel = transform.Find("Pause_Game_Panel");
        this.moneyText = transform.Find("Game_Panel").Find("Coin").GetComponent<Text>();
    }

    protected override void Start() 
    {
        base.Start();
        GameController.Instance.MoneyEvent += this.ChangeNumberMoney;
        this.ChangeNumberMoney(this, System.EventArgs.Empty);
    }

    private void ChangeNumberMoney(
        object sender, 
        System.EventArgs e
    ) => this.moneyText.text = GameController.Instance.MoneyNumber.ToString();
}
