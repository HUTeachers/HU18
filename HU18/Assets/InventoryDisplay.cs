using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour {
    [SerializeField]
    GameObject lootItemPrefab;
	// Use this for initialization
	void OnEnable () {
        foreach (LootItem item in GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().ContainedItems())
        {
            CreateItem(item);
        }
        
        GameManager.itemPickupEvent += CreateItem;

	}

    public void CreateItem(LootItem lootItem)
    {
        
        GameObject newItem = Instantiate(lootItemPrefab, transform);
        newItem.GetComponent<InventoryItem>().UpdateItem(lootItem);
    }

    private void OnDisable()
    {
        GameManager.itemPickupEvent -= CreateItem;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }

}
