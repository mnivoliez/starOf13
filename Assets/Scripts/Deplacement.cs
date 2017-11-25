using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

    [SerializeField] private float speed = 0.1f;
    private Vector2 mvt;
    private float inputX;
    private float inputY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        mvt = new Vector2(speed * inputX, speed * inputY);
    }

    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = mvt;
        //transform.Translate(mvt.x, mvt.y, 0);
        if (inputX == 0 && inputY > 0)
        {
            GetComponent<Direction>().Set(1);
        }
        else if (inputX > 0 && inputY > 0)
        {
            GetComponent<Direction>().Set(2);
        }
        else if (inputX > 0 && inputY == 0)
        {
            GetComponent<Direction>().Set(3);
        }
        else if (inputX > 0 && inputY < 0)
        {
            GetComponent<Direction>().Set(4);
        }
        else if (inputX == 0 && inputY < 0)
        {
            GetComponent<Direction>().Set(5);
        }
        else if (inputX < 0 && inputY < 0)
        {
            GetComponent<Direction>().Set(6);
        }
        else if (inputX < 0 && inputY == 0)
        {
            GetComponent<Direction>().Set(7);
        }
        else if (inputX < 0 && inputY > 0)
        {
            GetComponent<Direction>().Set(8);
        }
    }
}
