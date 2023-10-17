using System.Diagnostics;

public class NewLog : AutoMonoBehaviour
{
#if UNITY_EDITOR
    [Conditional("ENABLE_LOG")]
    public static void DebugLog(string message) =>
        UnityEngine.Debug.Log(message: message);

    [Conditional("ENABLE_LOG")]
    public static void DebugLog(string message, object Object) =>
       UnityEngine.Debug.Log(message: message);

    [Conditional("ENABLE_LOG")]
    public static void DebugLogWarning(string message) =>
        UnityEngine.Debug.LogWarning(message: message);

    [Conditional("ENABLE_LOG")]
    public static void DebugLogError(string message) =>
       UnityEngine.Debug.LogError(message: message);
#endif
}
