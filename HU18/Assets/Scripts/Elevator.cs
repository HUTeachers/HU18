﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    GroundCheck groundCheck;
    [SerializeField]
    float maxrise = 4;

    public float speed = 30;

    private float originalY;
	// Use this for initialization
	void Start () {
        originalY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		if(groundCheck != null && originalY + maxrise > transform.position.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (groundCheck == null && originalY < transform.position.y)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if (collision.GetComponent<GroundCheck>() != null)
        {
            groundCheck = collision.GetComponent<GroundCheck>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<GroundCheck>() != null)
        {
            groundCheck = null;
        }
    }

}
