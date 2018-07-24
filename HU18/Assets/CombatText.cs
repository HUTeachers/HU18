using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.damageEvent.AddListener(CombatTextDemonstration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CombatTextDemonstration(GameObject damagetaker, float damage)
	{
		Debug.Log("Hej Daniel, vidste du at " + damagetaker.name + " tog hele " + damage + " skade");
	}

}
