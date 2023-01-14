using UnityEngine;

public class Logger
{
    static public void Log(string message)
    {
        #if (UNITY_EDITOR)
        Debug.Log("DEBUG: " + message);
        #endif
    }
}
