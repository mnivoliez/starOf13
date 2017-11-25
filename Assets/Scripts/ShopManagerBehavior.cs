using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The goal here is to propose a manager which generate item stand on the go at the "opening" of the store.
 **/
public class ShopManagerBehavior : MonoBehaviour {
	[SerializeField] private ShopItemStandBehavior _itemStandPrefab;
	[SerializeField] private bool _is_open;
	[SerializeField] private List<ItemBase> _base_items;
	private List<ShopItemStandBehavior> _stands;

	// Use this for initialization
	void Start () {
		_base_items = new List<ItemBase> ();
		_stands = new List<ShopItemStandBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenShop () {
		GenerateStands ();
		_is_open = true;
	}

	public void CloseShop () {
		foreach (ShopItemStandBehavior stand in _stands) {
			Destroy (stand);
		}
		_is_open = false;	
	}

	private void GenerateStands () {
		foreach (ItemBase ib in _base_items) {
			ShopItemStandBehavior sis = Instantiate (_itemStandPrefab, Vector3.forward, Quaternion.identity);
			sis.Init (ib.item_type, ib.base_price, ib.stock, ib.name, ib.description, ib.sprite);
			_stands.Add (sis);
		}
	}
}
