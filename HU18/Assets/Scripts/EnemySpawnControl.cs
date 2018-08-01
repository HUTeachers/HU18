using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if(GameManager.stateManager.state == RoomState.Clear)
        {
            gameObject.SetActive(false);
        }
        else
        {
            RoomStateManager.enemySpawn.Invoke(1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        if (GameManager.stateManager.state != RoomState.Clear)
        {
            RoomStateManager.enemySpawn.Invoke(-1);
            gameObject.SetActive(false);
        }
    }

}
