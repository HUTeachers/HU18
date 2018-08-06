using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum WallStatus
{
    None,
    Left,
    Right
}

public class WallCheck : MonoBehaviour {
    private BoxCollider2D[] colliders2D = new BoxCollider2D[2];
    private BoxCollider2D left
    {
        get
        {
            return colliders2D[0];
        }
    }
    private BoxCollider2D right
    {
        get
        {
            return colliders2D[1];
        }
    }

    bool onLeftWall = false;
    bool onRightWall = false;
	// Use this for initialization
	void Start () {
        colliders2D = GetComponents<BoxCollider2D>().OrderBy(x => x.offset.x).ToArray();
	}
	

    public bool GetWallStatus()
    {
        return onLeftWall || onRightWall;
    }

    public float GetDirection()
    {
        if (onLeftWall)
        {
            
            return 1f;
        }
        else if (onRightWall)
        {
            
            return -1f;
        }
        else
        {
            return 0;
        }
    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        SetWallStates(collision, true);
    }

    private void SetWallStates(Collider2D collider, bool state)
    {
        if(!state)
        {
            onRightWall = state;
            onLeftWall = state;
            return;
        }
        Collider2D[] points = new Collider2D[5];
        collider.GetContacts(points);
        if (points.Contains(right))
        {
            onRightWall = state;
        }
        else if (points.Contains(left))
        {
            onLeftWall = state;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetWallStates(collision, false);
    }
}
