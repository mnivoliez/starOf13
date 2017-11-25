using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

	[SerializeField] private float speed = 1f;
	private Vector2 mvt;
	private float inputX;
	private float inputY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxisRaw ("Horizontal");
		inputY = Input.GetAxisRaw ("Vertical");
		mvt = new Vector2 (speed * inputX, speed * inputY);
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = mvt;
		if (inputX == 0 && inputY > 0) {
			GetComponent<MDirection> ().Set (Direction.TOP);
		} else if (inputX > 0 && inputY == 0) {
			GetComponent<MDirection> ().Set (Direction.RIGHT);
		} else if (inputX == 0 && inputY < 0) {
			GetComponent<MDirection> ().Set (Direction.BOTTOM);
		} else if (inputX < 0 && inputY == 0) {
			GetComponent<MDirection> ().Set (Direction.LEFT);

		}
	}
}
