using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {
    LootItem lootItem;
    Image image;
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateItem(LootItem updateItem)
    {
        image = GetComponent<Image>();
        lootItem = updateItem;
        image.sprite = lootItem.InGameSprite;
        image.color = lootItem.InGameColor;
    }

}
