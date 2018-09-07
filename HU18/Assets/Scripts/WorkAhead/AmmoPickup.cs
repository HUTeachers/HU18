using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if(player.gameObject.CompareTag("Player"))
        {
            player.GetComponentInChildren<FiringManagementLevels>().UpgradeGun();

        }
	}
}
