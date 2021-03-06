﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpdater : MonoBehaviour {
    [SerializeField]
    private string PlayerTag = "Player";

    Image image;
    // Use this for initialization
    void Start () {
        GameManager.damageEvent += PlayerDamageListener;
        image = GetComponent<Image>();
        if(GameManager.instance.DebugMode)
        {
#if UNITY_EDITOR
			if (!this.CheckForTag(PlayerTag))
            {
                Debug.LogWarning("Player tag not found: " + PlayerTag);
            }
#endif
		}
	}

    /// <summary>
    /// Opdatere health orben.
    /// </summary>
    /// <param name="go"></param>
    /// <param name="damage"></param>
    void PlayerDamageListener(GameObject go, float damage)
    {
        if (go.CompareTag(PlayerTag))
        {
            float temp = (float)go.GetComponent<Health>().GetHealth() / (float)100;
            image.material.SetFloat("Vector1_B7AA170B", temp);
        }
    }

    //Remember to remove events
    private void OnDisable()
    {
        GameManager.damageEvent -= PlayerDamageListener;
    }

}
