using System;
using System.Linq;
using UnityEditorInternal;
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
    public static bool CheckForTag(this MonoBehaviour GameObject, string tagCheck)
    {
        return InternalEditorUtility.tags.Contains(tagCheck);
    }

    public static Vector3 Vector2ToVector3(this Vector2 vec2)
    {
        return new Vector3(vec2.x, vec2.y, 0f);
    }
}
