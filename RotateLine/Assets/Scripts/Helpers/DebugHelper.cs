using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHelper
{
    public static void Log(string log)
    {
        Debug.Log(log);
    }

    public static void LogWarning(string log)
    {
        Debug.LogWarning(log);
    }

    public static void LogError(string log)
    {
        Debug.LogError(log);
    }
}
