using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{

	private Rigidbody2D playerBody;

	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		if (!gameObject.CompareTag("Player"))
		{
			Debug.LogWarning("Flipperen sidder ikke på en player!");
		}
		else
		{
			playerBody = GetComponent<Rigidbody2D>();
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerBody.velocity.x > 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (playerBody.velocity.x < 0)
		{
			spriteRenderer.flipX = true;
		}
	}
}
