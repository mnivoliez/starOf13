using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
	FOOD,
	BASEBALL_BAT
}

[System.Serializable]
public class ItemBase {
	public ItemType item_type;
	public int base_price;
	public int stock;
	public string description;
	public string name;
}

/**
 * Contain the data for specific item.
 **/
public class ShopItemStandBehavior : MonoBehaviour, IInteractable {

	[SerializeField] private ItemType _item_type;
	[SerializeField] private int _price;
	[SerializeField] private int _stock;
	[SerializeField] private string _description;
	[SerializeField] private string _name;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public ItemType GetItemType () {
		return _item_type;
	}

	public int GetPrice () {
		return _price;
	}

	public string GetDescription () {
		return _description;
	}

	public int GetStock () {
		return _stock;
	}

	public void TakeOne () {
		_stock--;
	}

	public void Init (ItemType it, int price, int stock, string name, string description) {
		_item_type = it;
		_price = price;
		_stock = stock;
		_name = name;
		_description = description;
	}

	public void Interact (GameObject go) {
		InventoryController ic = go.GetComponent<InventoryController> ();
		if (ic) {
			ic.TryBuyItem (this);
		}
	}
		
}
