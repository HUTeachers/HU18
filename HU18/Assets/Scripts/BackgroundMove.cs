using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour {
	Image img;
    Transform player;

    [SerializeField]
    private bool ScrollWithPlayer = true;

    [SerializeField]
    private float Dampening = 100f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		//_MainTex er en reference til texturen på materialet, for some reason.

        if(ScrollWithPlayer)
        {
            img.material.SetTextureOffset("_MainTex", new Vector2(player.position.x / Dampening, player.position.y / Dampening));
        }
        else
        {
            img.material.SetTextureOffset("_MainTex", new Vector2((Time.timeSinceLevelLoad / 4f) % img.mainTexture.width, 0f));
        }
	}
}
