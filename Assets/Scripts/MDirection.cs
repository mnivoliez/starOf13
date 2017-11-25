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

	private int direction;

	// Use this for initialization
	void Start () {
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Set (int dir) {
		direction = dir;
	}

	public int Get () {
		return direction;
	}
}
