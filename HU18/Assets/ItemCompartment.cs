using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCompartment : MonoBehaviour {

    [SerializeField]
    private LootItem carriedItem;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = carriedItem.InGameSprite;
        sr.color = carriedItem.InGameColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public LootItem GetItem()
    {

        return carriedItem;

    }
}
