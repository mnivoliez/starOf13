using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	bool interacting = false;
	BoxCollider2D interaction = null;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!interacting) {
			if (Input.GetButtonDown ("Fire2")) {
				Vector2 charSize = GetComponent<Renderer> ().bounds.size;

				interaction = gameObject.AddComponent<BoxCollider2D> () as BoxCollider2D;
				interaction.isTrigger = true;

				switch (GetComponent<MDirection> ().Get ()) {
				case Direction.TOP:
					interaction.size = new Vector2 (charSize.x, 0.1f);
					interaction.offset = new Vector2 (0, charSize.y);
					break;
				case Direction.RIGHT:
					interaction.size = new Vector2 (0.1f, charSize.y);
					interaction.offset = new Vector2 (charSize.x, 0);
					break;
				case Direction.BOTTOM:
					interaction.size = new Vector2 (charSize.y, 0.1f);
					interaction.offset = new Vector2 (0, -charSize.y);
					break;
				case Direction.LEFT:
					interaction.size = new Vector2 (0.1f, charSize.y);
					interaction.offset = new Vector2 (-charSize.x, 0);
					break;
				default:
					break;
				}

				interacting = true;
			}
		} else if (interaction != null) {
			Destroy (interaction);
			interacting = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		IInteractable ii = other.GetComponent<IInteractable> ();
		if (ii != null && interacting) {
			ii.Interact (gameObject);
			Destroy (interaction);
			interacting = false;
		}
	}


}
