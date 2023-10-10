using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLoadConfigData<T> : AutoMonoBehaviour where T: ScriptableObject
{
    [Header("[ Database ]"), Space(6)]
    [SerializeField] protected T dataSO;
    protected string nameConfig = "";
    protected readonly string DIRECTION = "Config/";

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        string Path = DIRECTION + this.nameConfig + "/" 
            + this.RemoveCloneText(transform.parent.name) + " " + nameConfig;
        this.dataSO = Resources.Load<T>(Path);
    }

    protected virtual void SetNameConfig(string name) => this.nameConfig = name;

    protected virtual string RemoveCloneText(string name)
    {
        string textNeedRemove = "(Clone)";
        if (!name.Contains(textNeedRemove)) return name;

        int startIndex = name.Length - textNeedRemove.Length;
        int lengthToRemove = textNeedRemove.Length;
        return name.Remove(startIndex, lengthToRemove);
    }
}
