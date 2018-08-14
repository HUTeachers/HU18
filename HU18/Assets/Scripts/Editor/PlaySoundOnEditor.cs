using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlaySoundOn))]
public class PlaySoundOnEditor : Editor {

	bool showKeys;
	PlaySoundOn scriptRef;
	SoundEnum test;

    void OnEnable()
	{
		scriptRef = target as PlaySoundOn;
	}


	public override void OnInspectorGUI()
	{
		//Authentic gray script field.	
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((PlaySoundOn)target), typeof(PlaySoundOn), false);
		GUI.enabled = true;

		scriptRef.soundEnum = (SoundEnum)EditorGUILayout.EnumPopup("Lyd på:", scriptRef.soundEnum);

        EditorGUILayout.Space();

		switch (scriptRef.soundEnum)
		{

			case SoundEnum.OnCollision:
			case SoundEnum.OnTrigger:
				scriptRef.RequireTag = EditorGUILayout.Toggle("Kræver tag?", scriptRef.RequireTag);
				scriptRef.RequiredTag = EditorGUILayout.TextField(new GUIContent("Krævet tag:"), scriptRef.RequiredTag);
				break;
			case SoundEnum.OnActivate:
				break;
			case SoundEnum.OnInput:
				List<KeyCode> temp = scriptRef.inputKeys;

                int editorlistSize = Mathf.Max(0, EditorGUILayout.IntField("Antal keys", temp.Count));
				
                //Expand list
				while(editorlistSize > temp.Count)
				{
					temp.Add(KeyCode.A);
				}

                //Shorten list
				while(editorlistSize < temp.Count )
				{
					temp.RemoveAt(temp.Count - 1);
				}

				EditorGUI.indentLevel++;
				showKeys = EditorGUILayout.Foldout(showKeys,"Keys " );
				if(showKeys)
				{
					for (int i = 0; i < temp.Count; i++)
					{
						temp[i] = (KeyCode)EditorGUILayout.EnumPopup(new GUIContent(i.ToString()), temp[i]);
					}
				}
				
				EditorGUI.indentLevel--;
				break;
			default:
				break;
		}
	}


}
