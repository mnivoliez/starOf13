using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taper : MonoBehaviour {
	bool hitting = false;
	BoxCollider2D hit = null;
	float knockback = 0.3f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!hitting) {
			if (Input.GetButtonDown ("Fire1")) {
				GetComponent<Animator> ().SetBool ("isHitting", true);

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
			Destroy (hit);
			hitting = false;
			GetComponent<Animator> ().SetBool ("isHitting", false);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.GetComponent<Hittable> () != null && hitting) {
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
			Destroy (hit);
			hitting = false;
		}
	}
}
