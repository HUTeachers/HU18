using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpdater : MonoBehaviour {

    public string PlayerTag = "Player";

    Image image;
    

    // Use this for initialization
    void Start () {
        GameManager.damageEvent.AddListener(PlayerDamageListener);
        image = GetComponent<Image>();
        image.material.SetFloat("FillAmount", 0.5f);
        
        
        

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayerDamageListener(GameObject go, float damage)
    {
        if (go.tag == PlayerTag)
        {
            float temp = (float)go.GetComponent<Health>().GetHealth() / (float)100;
            image.material.SetFloat("Vector1_B7AA170B", temp);
        }
    }

}
