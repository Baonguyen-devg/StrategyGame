using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BaseLoadConfigData<T> : AutoMonoBehaviour where T: ScriptableObject
{
    #region Variables
    [Header("[ Database ]"), Space(6)]
    [SerializeField] protected T dataSO;

    protected string nameConfig = "";
    protected readonly string DIRECTION = "Config/";
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        string Path = this.StringBuilderPath();
        NewLog.DebugLog(Path);
        this.dataSO = Resources.Load<T>(Path);
    }
    #endregion

    #region Main methods
    protected virtual string StringBuilderPath()
    {
        StringBuilder stringBuilder = new StringBuilder();
        return stringBuilder.Append(DIRECTION)
            .Append(nameConfig)
            .Append("/")
            .Append(this.RemoveCloneText(transform.parent.name))
            .Append(" ").Append(nameConfig).ToString();
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
    #endregion
}
