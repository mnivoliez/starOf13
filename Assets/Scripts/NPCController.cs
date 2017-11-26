using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IPhaseDriven {
	private NPCBisounoursBehavior _bisounours;
	private NPCJasonBehavior _jason;
    private FollowPath[] _FollowPaths;


    // Use this for initialization
    void Start () {
		_bisounours = gameObject.GetComponent<NPCBisounoursBehavior> ();
		_jason = gameObject.GetComponent<NPCJasonBehavior> ();
        _FollowPaths = GetComponentsInParent<FollowPath>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterPhase (Phase phase) {
		switch (phase) {
		case Phase.BISOUNOURS:
            GetComponent<Animator>().SetBool("isEvil", false);
			_bisounours.enabled = true;
			_jason.enabled = false;
            foreach (FollowPath _FollowPath in _FollowPaths)
            {
                _FollowPath.enabled = true;
            }
            GetComponent<NPCTaper>().enabled = false;
            GetComponent<Hittable>().enabled = false;
            break;
		case Phase.FRIDAY_13:
            GetComponent<Animator>().SetBool("isEvil", true);
           _bisounours.enabled = false;
			_jason.enabled = true;
            foreach (FollowPath _FollowPath in _FollowPaths)
            {
                _FollowPath.enabled = false;
            }
            GetComponent<NPCTaper>().enabled = true;
            GetComponent<Hittable>().enabled = true;
            
            break;
		}
	}
}
