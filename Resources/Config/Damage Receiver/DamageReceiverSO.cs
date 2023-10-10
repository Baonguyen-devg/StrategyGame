using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Receiver", menuName = "ScriptableObjects/Damage Receiver")]
public class DamageReceiverSO : ScriptableObject
{
    #if UNITY_EDITOR
    [TextArea(2, 10), Space(6)] 
    [SerializeField] private string DeveloperDescribe = "";
    #endif

    [Header("Database"), Space(6)]
    [SerializeField] private int currentHealth = default;
    [SerializeField] private int maximumHealth = default;

    public virtual int GetCurrentHealth() => this.currentHealth;
    public virtual int GetMaximumHealth() => this.maximumHealth;  
}
