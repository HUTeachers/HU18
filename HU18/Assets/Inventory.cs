using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    List<LootItem> items;
	// Use this for initialization
	void Start () {
        if(items == null)
        {
            items = new List<LootItem>();
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCompartment item = collision.GetComponent<ItemCompartment>();
        if (item != null)
        {
            items.Add(item.GetItem());

            collision.gameObject.SetActive(false);
        }
    }

    internal bool KeyCheck(KeyEnum requiredKey)
    {
        return items.Exists(x => x.key == requiredKey) || requiredKey == KeyEnum.None;
    }
}
