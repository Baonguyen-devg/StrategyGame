using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObjects/Movement")]
public class MovementSO : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea, SerializeField] private string DeveloperDescribe = "";
#endif

    private const float DEFAULT_SPEED = 0.01f;
    private const float DEFAULT_MAXINMUM_SPEED = 10f;
    private const float DEFAULT_MINIMUM_SPEED = 0f;

    #region Variables
    [Header("Database"), Space(6)]
    [SerializeField] private float speed = DEFAULT_SPEED;
    [SerializeField] private float maximumSpeed = DEFAULT_MAXINMUM_SPEED;
    [SerializeField] private float minimumSpeed = DEFAULT_MINIMUM_SPEED;
    #endregion

#nullable disable warnings //This code only use for practice, dont't have mean in this case
    public virtual float GetSpeed() => this.speed;
    public virtual float GetMaximumSpeed() => this.maximumSpeed;
    public virtual float GetMinimumSpeed() => this.minimumSpeed;
#nullable enable warnings
}
