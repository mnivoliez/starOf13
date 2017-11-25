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

	void TryBuyItem (ItemBehavior item) {
		if (item.GetPrice () <= _money) {
			switch (item.GetItemType ()) {
			case ItemType.FOOD:
				_slot_health++;
				_money -= item.GetPrice ();
				break;
			case ItemType.BASEBALL_BAT:
				if (!_has_baseball_bat) {
					_money -= item.GetPrice ();
					_has_baseball_bat = true;
				} else {
					Debug.Log ("Already has a bat");
				}			
			}
		}
	}
}
