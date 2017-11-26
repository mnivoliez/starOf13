﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTaper : MonoBehaviour {

	bool hitting = false;
	BoxCollider2D hit = null;
	float knockback = 0.3f;
	public float _time;
	public float step = 0.4f;

	// Use this for initialization
	void Start () {
		_time = 0f;
	}

	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;
		if (!hitting) {
			if (_time > step) {
				Debug.Log ("Heyhey");
				_time = 0f;
				Vector2 charSize = GetComponent<Renderer> ().bounds.size;
				hit = gameObject.AddComponent<BoxCollider2D> () as BoxCollider2D;
				hit.isTrigger = true;

				switch (GetComponent<MDirection> ().Get ()) {
				case Direction.TOP:
					hit.size = new Vector2 (charSize.x, 0.1f);
					hit.offset = new Vector2 (0, charSize.y);
					break;
				case Direction.RIGHT:
					hit.size = new Vector2 (0.1f, charSize.y);
					hit.offset = new Vector2 (charSize.x, 0);
					break;
				case Direction.BOTTOM:
					hit.size = new Vector2 (charSize.y, 0.1f);
					hit.offset = new Vector2 (0, -charSize.y);
					break;
				case Direction.LEFT:
					hit.size = new Vector2 (0.1f, charSize.y);
					hit.offset = new Vector2 (-charSize.x, 0);
					break;
				default:
					break;
				}

				hitting = true;
			}
		} else if (hit != null) {
			Debug.Log ("Hoho");

			Destroy (hit);
			hitting = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<Hittable> () as Hittable != null && hitting) {
			switch (GetComponent<MDirection> ().Get ()) {
			case Direction.TOP:
				other.gameObject.transform.Translate (0, knockback, 0);
				break;
			case Direction.RIGHT:
				other.gameObject.transform.Translate (knockback, 0, 0);
				break;
			case Direction.BOTTOM:
				other.gameObject.transform.Translate (0, -knockback, 0);
				break;
			case Direction.LEFT:
				other.gameObject.transform.Translate (-knockback, 0, 0);
				break;
			default:
				break;
			}
			Debug.Log ("hit");
			Destroy (hit);
			hitting = false;
		}
	}
}
