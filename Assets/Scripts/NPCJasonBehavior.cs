using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJasonBehavior : MonoBehaviour {
	[SerializeField]
	private Polarith.AI.Move.AIMSimpleController2D _aim_controller;

	void Awake () {
		_aim_controller = gameObject.GetComponent<Polarith.AI.Move.AIMSimpleController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
		_aim_controller.enabled = true;
	}

	void OnDisable () {
		_aim_controller.enabled = false;
	}
}
