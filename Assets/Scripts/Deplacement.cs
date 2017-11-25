using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Vector2 mvt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        mvt = new Vector2(speed * inputX, speed * inputY);
    }

    void FixedUpdate()
    {
        transform.Translate(mvt.x, mvt.y, 0);
    }
}
