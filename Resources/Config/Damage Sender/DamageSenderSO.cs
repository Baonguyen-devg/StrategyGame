using UnityEngine;

[CreateAssetMenu(fileName = "Damage Sender", menuName = "ScriptableObjects/Damage Sender")]
public class DamageSenderSO : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea, SerializeField] private string DeveloperDescribe = "";
#endif

    private const int DEFAULT_DAME = 100;
    private const int DEFAULT_MAXIMUM_DAME = 1000;

    #region Variables
    [Header("Database"), Space(6)]
    [SerializeField] private int dame = DEFAULT_DAME;
    [SerializeField] private int maximumDame = DEFAULT_MAXIMUM_DAME;
    #endregion

#nullable disable warnings //This code only use for practice, dont't have mean in this case
    public virtual int GetDame() => this.dame;
    public virtual int GetMaximumDame() => this.maximumDame;
#nullable enable warnings
}
