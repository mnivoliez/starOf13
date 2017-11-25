using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taper : MonoBehaviour
{

    bool hitting = false;
    BoxCollider2D hit = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hitting)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                hit = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                hit.isTrigger = true;
                hit.size = new Vector2(0.1f, GetComponent<Renderer>().bounds.size.y);

                hit.offset = new Vector2(GetComponent<Renderer>().bounds.size.x, 0);
                hitting = true;
            }
        }
        else if (hit != null)
        {
            Destroy(hit);
            hitting = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Hittable>() as Hittable != null && hitting)
        {
            other.gameObject.transform.Translate(0.3f, 0, 0);
            Destroy(hit);
            hitting = false;
        }
    }
}
