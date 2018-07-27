using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLifespan : MonoBehaviour {

	public float LifeTime = 4f;
    public string collisionDieTag = "Foe";

    

    // Use this for initialization
    void Start () {
		Destroy(this.gameObject, LifeTime);

        if(GameManager.instance.DebugMode)
        {
            if (!this.CheckForTag(collisionDieTag))
            {
                Debug.LogWarning("Lifespan: Tag undefined, no tag available called: " + collisionDieTag);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == collisionDieTag)
        {
            StartCoroutine(KillNextFrame());
        }
    }

    //Overflow Behavior
    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnTriggerEnter2D(collision.collider);
    }

    IEnumerator KillNextFrame()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }

}
