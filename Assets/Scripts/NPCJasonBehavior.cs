using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJasonBehavior : MonoBehaviour {
	private Polarith.AI.Move.AIMSimpleController2D _aim_controller;
	private Hittable _hittable;

	void Awake () {
		_aim_controller = gameObject.GetComponent<Polarith.AI.Move.AIMSimpleController2D> ();
		_hittable = gameObject.GetComponent<Hittable> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
		_aim_controller.enabled = true;
		_hittable.enabled = true;
	}

	void OnDisable () {
		_aim_controller.enabled = false;
		_hittable.enabled = false;
	}
}
