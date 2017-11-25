﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
	FOOD,
	BASEBALL_BAT
}

public class ShopItemStandBehavior : MonoBehaviour {

	[SerializeField] private ItemType _item_type;
	[SerializeField] private int _price;
	[SerializeField] private int _stock;
	[SerializeField] private string _description;

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
}
