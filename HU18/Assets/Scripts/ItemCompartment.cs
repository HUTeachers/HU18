using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCompartment : MonoBehaviour {

    [SerializeField]
    private LootItem carriedItem;
    [SerializeField]
    bool locked = false;
    [SerializeField]
    KeyEnum requiredKey = KeyEnum.None;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        if(!locked)
        {
            sr.sprite = carriedItem.InGameSprite;
            sr.color = carriedItem.InGameColor;
        }
        
        
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>();
        if (inventory != null)
        {
            if(!locked || locked && inventory.KeyCheck(requiredKey))
            {
                inventory.AddItem(carriedItem);
                gameObject.SetActive(false);
            }
            
        }
    }

}
