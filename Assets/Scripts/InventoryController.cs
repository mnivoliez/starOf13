using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	[SerializeField] private int _money;
	[SerializeField] private int _slot_health;
	[SerializeField] private bool _has_baseball_bat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TryBuyItem (ShopItemStandBehavior item) {
		if (CanBuy (item)) {
			switch (item.GetItemType ()) {
			case ItemType.FOOD:
				_slot_health++;
				item.TakeOne ();
				_money -= item.GetPrice ();
				break;
			case ItemType.BASEBALL_BAT:
				if (!_has_baseball_bat) {
					_money -= item.GetPrice ();
					item.TakeOne ();
					_has_baseball_bat = true;
				} else {
					Debug.Log ("Already has a bat");
				}			
				break;
			}
		}
	}

	private bool CanBuy (ShopItemStandBehavior item) {
		return item.GetStock () > 0 && item.GetPrice () >= _money;
	}
}
