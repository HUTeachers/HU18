using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Warning: This script dosn't work. - Canvas cannot accept camera that is in a different scene, apparently.
/// </summary>
public class GrabMainCamOnLoad : MonoBehaviour {
    Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();

        SceneManager.activeSceneChanged += GrabNewMainCam;
        Debug.LogError("This Script is broken, Don't use it.");

    }

    private void GrabNewMainCam(Scene a, Scene b)
    {
        canvas.worldCamera = Camera.main;
    }
}
