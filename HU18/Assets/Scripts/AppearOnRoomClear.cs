using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnRoomClear : MonoBehaviour {

    private void OnEnable()
    {
        RoomStateManager.roomClear.AddListener(AppearOnClear);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AppearOnClear()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        if(GetComponent<Collider2D>() != null)
        {
            GetComponent<Collider2D>().enabled = true;
        }
            
    }


    private void OnDisable()
    {
        RoomStateManager.roomClear.RemoveListener(AppearOnClear);
    }
}
