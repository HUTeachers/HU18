using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {
    private string Tag = "Player";
    Vector3 offset = Vector3.back * 10;
    Transform playerPos;
    Rigidbody2D playerRb;
    Vector3 speed = Vector3.zero;

	// Use this for initialization
	void Start () {
        playerPos = GameObject.FindGameObjectWithTag(Tag).transform;
        playerRb = playerPos.gameObject.GetComponent<Rigidbody2D>();
        if(GameManager.instance.DebugMode)
        {
            if (!this.CheckForTag(tag))
            {
                Debug.LogWarning("Player Tag Not Found: " + tag);
            }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.SmoothDamp(transform.position, playerPos.position + offset + playerRb.velocity.Vector2ToVector3(), ref speed, 0.5f);
	}
}
