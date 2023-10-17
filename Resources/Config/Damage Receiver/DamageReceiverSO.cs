using UnityEngine;

[CreateAssetMenu(fileName = "Damage Receiver", menuName = "ScriptableObjects/Damage Receiver")]
public class DamageReceiverSO : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea, SerializeField] private string DeveloperDescribe = "";
#endif

    private const int DEFAULT_CURRENT_HEALTH = 100;
    private const int DEFAULT_MAXIMUM_HEALTH = 10000;

    #region Variables
    [Header("Database"), Space(6)]
    [SerializeField] private int currentHealth = DEFAULT_CURRENT_HEALTH;
    [SerializeField] private int maximumHealth = DEFAULT_MAXIMUM_HEALTH;
    #endregion

#nullable disable warnings //This code only use for practice, dont't have mean in this case 
    public virtual int GetCurrentHealth() => this.currentHealth;
    public virtual int GetMaximumHealth() => this.maximumHealth;
#nullable enable warnings
}
