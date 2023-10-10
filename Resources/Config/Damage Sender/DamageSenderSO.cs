using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Sender", menuName = "ScriptableObjects/Damage Sender")]
public class DamageSenderSO : ScriptableObject
{
    #if UNITY_EDITOR
    [TextArea(2, 10), Space(6)]
    [SerializeField] private string DeveloperDescribe = "";
    #endif

    [Header("Database"), Space(6)]
    [SerializeField] private int dame = default;
    [SerializeField] private int maximumDame = default;

    public virtual int GetDame() => this.dame;
    public virtual int GetMaximumDame() => this.maximumDame;
}
