using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
	TOP,
	BOTTOM,
	RIGHT,
	LEFT
}

public class MDirection : MonoBehaviour {

	private Direction direction;

	// Use this for initialization
	void Start () {
		direction = Direction.BOTTOM;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Set (Direction dir) {
		direction = dir;
	}

	public Direction Get () {
		return direction;
	}
}
