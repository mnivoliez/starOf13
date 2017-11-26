using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class NPCBisounoursBehavior : MonoBehaviour, IInteractable {
	private FollowPath[] _FollowPaths;

	// Use this for initialization
	void Start () {
		_FollowPaths = GetComponentsInParent<FollowPath> ();
    }

	// Update is called once per frame
	void Update () {

	}

    public void Interact(GameObject player)
    {
        //GameObject.FindGameObjectWithTag("Audio").GetComponent<>().Play("nom_du_son/musique");
        int dialogueNumber = Random.Range(1, 4);

        switch (dialogueNumber)
        {
            case 1:
                GameObject.FindGameObjectWithTag("Text_dial").GetComponent<Text>().text = "Cas 1";
                break;
            case 2:
                GameObject.FindGameObjectWithTag("Text_dial").GetComponent<Text>().text = "Cas 2";
                break;
            case 3:
                GameObject.FindGameObjectWithTag("Text_dial").GetComponent<Text>().text = "Cas 3";
                break;
            case 4:
                GameObject.FindGameObjectWithTag("Text_dial").GetComponent<Text>().text = "Cas 4";
                break;
        }
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
