using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    List<LootItem> items;
	// Use this for initialization
	void Start () {
        //Makes sure that the list cannot be null.
        if(items == null)
        {
            items = new List<LootItem>();
        }
        GameManager.itemPickupEvent += AddItem;
	}

    private void AddItem(LootItem item)
    {
        items.Add(item);
    }

    public bool AllowItem(LootItem item)
    {
        return !items.Contains(item);
    }

    internal bool KeyCheck(KeyEnum requiredKey)
    {
        return items.Exists(x => x.key == requiredKey) || requiredKey == KeyEnum.None;
    }
}
