using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBack : MonoBehaviour {
	Vector3 speed = Vector3.zero;

    Rigidbody2D rb2dParentRef;

	// Use this for initialization
	void Start () {
        rb2dParentRef = transform.parent.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, transform.parent.position, ref speed, Mathf.Clamp01(0.11f - (rb2dParentRef.velocity.magnitude / 33) ));	
	}


}
