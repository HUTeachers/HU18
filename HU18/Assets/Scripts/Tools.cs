using System;
using UnityEngine;

public static class Tools  {

    public static void InstanceTrick<T>(this T script, ref T scriptInstance) where T : MonoBehaviour
    {
        if (scriptInstance == null)
        {
            scriptInstance = script;
        }
        else
        {
            MonoBehaviour.Destroy(script.gameObject);
        }
    }

	public static bool CheckForComponent<T>(this MonoBehaviour GameObject) where T : Component
	{
		return GameObject.GetComponent<T>() != null;
	}
}
