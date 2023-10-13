using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InputController : AutoMonoBehaviour
{
    private static InputController instance;
    public static InputController Instance => instance;

    public event System.EventHandler EscapePressEvent;

    #region Main methods

    protected override void Awake()
    {
        base.Awake();
        InputController.instance = this;
        var escapePressStream = UniRx.Observable.EveryUpdate()
           .Where(_ => Input.GetKeyDown(KeyCode.Escape))
           .Subscribe(_ => this.OnEscapePress());
    }

    private void OnEscapePress() =>
        this.EscapePressEvent?.Invoke(null, System.EventArgs.Empty);

    #endregion
}
