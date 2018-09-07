using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

	public float speed;
	public float distance;

	private float initialY;
	private bool up;

	void Start () {
		initialY = transform.position.y;
		up = true;
	}
	
	void Update () {
		if(transform.position.y > initialY + distance)
			up = false;
		else if(transform.position.y <= initialY)
			up = true;

		if(up)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
		else
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed * -1);
		}
			
	}
}
