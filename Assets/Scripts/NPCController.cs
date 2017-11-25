using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IPhaseDriven {
	private NPCBisounoursBehavior _bisounours;
	private NPCJasonBehavior _jason;

	// Use this for initialization
	void Start () {
		_bisounours = gameObject.GetComponent<NPCBisounoursBehavior> ();
		_jason = gameObject.GetComponent<NPCJasonBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterPhase (Phase phase) {
		switch (phase) {
		case Phase.BISOUNOURS:
			_bisounours.enabled = true;
			_jason.enabled = false;
			break;
		case Phase.FRIDAY_13:
			_bisounours.enabled = false;
			_jason.enabled = true;
			break;
		}
	}
}
