using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Assures Only One Player Exists at any one time.
/// </summary>
public class PlayerManagement : MonoBehaviour {
    private static PlayerManagement instance;
	// Use this for initialization
	void Awake () {
        this.InstanceTrick<PlayerManagement>(ref instance);
	}
}
