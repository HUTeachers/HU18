using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
    private const int ClampedRotationLimit = 3;
    private const int UnClamlpedRotation = 99;
    Vector3 cameraPoint;
	float angle;

    public bool ClampRotation = false;

	// Use this for initialization
	void Start () {

        if(GameManager.instance.DebugMode)
        {
            if (!Camera.main.orthographic)
            {
                Debug.LogWarning("This script does not work in the current camera mode, change to ortographic.");
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        cameraPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cameraPoint -= transform.position;
        angle = Tools.VelocityToAngle(cameraPoint);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), ClampRotation ? ClampedRotationLimit : UnClamlpedRotation);  
	}
}
