using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBisounoursBehavior : MonoBehaviour {

	private FollowPath[] _FollowPaths;

	// Use this for initialization
	void Start () {
		_FollowPaths = GetComponentsInParent<FollowPath> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void EnterPhase (Phase phase) {
		switch (phase) {
		case Phase.BISOUNOURS:
			foreach (FollowPath _FollowPath in _FollowPaths) {
				_FollowPath.enabled = true;
			}
			GetComponent<NPCTaper> ().enabled = false;
			GetComponent<Hittable> ().enabled = false;
			break;
		case Phase.FRIDAY_13:
			foreach (FollowPath _FollowPath in _FollowPaths) {
				_FollowPath.enabled = false;
			}
			GetComponent<NPCTaper> ().enabled = true;
			GetComponent<Hittable> ().enabled = true;
			break;
		}
	}
}
