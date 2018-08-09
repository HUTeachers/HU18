using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour {
    [SerializeField]
    GameObject lootItemPrefab;
	// Use this for initialization
	void Start () {
		if(GameManager.instance.DebugMode)
        {
            
        }
        GameManager.itemPickupEvent += CreateItem;
	}

    public void CreateItem(LootItem lootItem)
    {
        
        GameObject newItem = Instantiate(lootItemPrefab, transform);
        newItem.GetComponent<InventoryItem>().UpdateItem(lootItem);
    }

}
