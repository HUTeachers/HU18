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

    public void AddItem(LootItem item)
    {
        items.Add(item);
    }

    internal bool KeyCheck(KeyEnum requiredKey)
    {
        return items.Exists(x => x.key == requiredKey) || requiredKey == KeyEnum.None;
    }
}
