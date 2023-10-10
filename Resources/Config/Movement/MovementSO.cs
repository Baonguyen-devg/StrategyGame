using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObjects/Movement")]
public class MovementSO : ScriptableObject
{
    #if UNITY_EDITOR
    [TextArea(2, 10), Space(6)]
    [SerializeField] private string DeveloperDescribe = "";
    #endif

    [Header("Database"), Space(6)]
    [SerializeField] private float speed;
    [SerializeField] private float maximumSpeed;
    [SerializeField] private float minimumSpeed;

    public virtual float GetSpeed() => this.speed;
    public virtual float GetMaximumSpeed() => this.maximumSpeed;
    public virtual float GetMinimumSpeed() => this.minimumSpeed;
}
