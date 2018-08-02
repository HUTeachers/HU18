using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// Assures Only One Player Exists at any one time.
/// </summary>
public class PlayerManagement : MonoBehaviour {
    private static PlayerManagement instance;
	// Use this for initialization
	void Awake () {
        this.InstanceTrick<PlayerManagement>(ref instance);
        if(instance == this)
        {
            SceneManager.activeSceneChanged += ResetPosition;
        }
        
	}
    
    void ResetPosition(Scene a, Scene b)
    {
        transform.position = Vector3.zero;
    }
}
