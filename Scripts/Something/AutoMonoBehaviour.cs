using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset() => this.LoadComponent();

    protected virtual void Awake() => this.LoadComponent();

    protected virtual void LoadComponent() { /* For Override */ }

    [SerializeField] protected bool haveLogger = false;

    protected virtual void Start() {
        StartCoroutine(routine: LoadWaitForShortTime());
        StartCoroutine(routine: LoadWaitForMediumTime());
        StartCoroutine(routine: LoadWaitForLongTime());
    }

    protected virtual IEnumerator LoadWaitForShortTime() {
        yield return new WaitForSeconds(seconds: 0.5f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForMediumTime() {
        yield return new WaitForSeconds(seconds: 1f);
        /* For Override */
    }

    protected virtual IEnumerator LoadWaitForLongTime() {
        yield return new WaitForSeconds(seconds: 1.5f);
        /* For Override */
    }

    protected void Logger(string message)
    {
        if (!this.haveLogger) return;
        NewLog.DebugLog(message: message);
    }
}
