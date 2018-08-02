using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceForward : MonoBehaviour {
    Rigidbody2D rb2d;
    [SerializeField]
    float offset = 90f;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.Euler(0, 0, Tools.VelocityToAngle(rb2d.velocity, 90f));
    }


}
