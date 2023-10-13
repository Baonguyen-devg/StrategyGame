using System.Diagnostics;

public class NewLog : AutoMonoBehaviour
{
#if UNITY_EDITOR
    [Conditional("ENABLE_LOG")]
    public static void DebugLog(string massenger) =>
        UnityEngine.Debug.Log(message: massenger);

    [Conditional("ENABLE_LOG")]
    public static void DebugLogWarning(string massenger) =>
        UnityEngine.Debug.LogWarning(message: massenger);

    [Conditional("ENABLE_LOG")]
    public static void DebugLogError(string massenger) =>
       UnityEngine.Debug.LogError(message: massenger);
#endif
}
