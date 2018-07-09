using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
	Vector3 temp;
	float angle;

	// Use this for initialization
	void Start () {
		if(!Camera.main.orthographic)
        {
            Debug.LogWarning("This script does not work in the current camera mode, change to ortographic.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
		temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		temp -= transform.position;
		angle = Mathf.Rad2Deg * Mathf.Atan2(temp.y, temp.x);
		transform.rotation = Quaternion.Euler(0, 0, angle );
        
	}
}
