using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
	FRIDAY_13,
	BISOUNOURS
}

public class PhaseManager : MonoBehaviour {
	[SerializeField] private float _phase_duration;
	[SerializeField] private Phase _current_phase;
	[SerializeField] private float _current_time;
	[SerializeField] ShopManagerBehavior _shop_manager;

	// Use this for initialization
	void Start () {
		BroadcastMessage ("EnterPhase", _current_phase);
	}
	
	// Update is called once per frame
	void Update () {
		if (_current_time > _phase_duration) {
			_current_time = 0f;
			ChangePhase ();
		} else {
			_current_time += Time.deltaTime;
		}
	}

	void ChangePhase () {
		switch (_current_phase) {
		case Phase.FRIDAY_13:
			_current_phase = Phase.BISOUNOURS;
			BroadcastMessage ("EnterPhase", Phase.BISOUNOURS);
			break;
		case Phase.BISOUNOURS:
			_current_phase = Phase.FRIDAY_13;
			BroadcastMessage ("EnterPhase", Phase.FRIDAY_13);
			break;
		}
	}
}
