using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTwo : MonoBehaviour {

	public string SceneToLoad = "Hej";

	public void LoadScene()
	{
		SceneManager.LoadScene(SceneToLoad);
	}

}
