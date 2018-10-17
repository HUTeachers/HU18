using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif
using UnityEngine;
using UnityEngine.Events;

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

#if UNITY_EDITOR
	public static bool CheckForTag(this MonoBehaviour GameObject, string tagCheck)
    {
        return InternalEditorUtility.tags.Contains(tagCheck);
    }
#endif

	public static Vector3 Vector2ToVector3(this Vector2 vec2)
    {
        return new Vector3(vec2.x, vec2.y);
    }

    public static Vector3 RandomizeVector(float randomFactor)
    {
        return new Vector3(UnityEngine.Random.Range(-randomFactor, randomFactor), UnityEngine.Random.Range(-randomFactor, randomFactor));
    }
    public static float VelocityToAngle(Vector3 vec3, float offset = 0f)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(vec3.y, vec3.x) + offset;
    }


}
