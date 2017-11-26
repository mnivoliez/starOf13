using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taper : MonoBehaviour
{
    bool hitting = false;
    BoxCollider2D hit = null;
    float knockback = 2f;

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

                switch (GetComponent<MDirection>().Get())
                {
                    case Direction.TOP:
                        hit.size = new Vector2(charSize.y / 10, charSize.x / 10);
                        hit.offset = new Vector2(0, charSize.y / 10);
                        break;
                    case Direction.RIGHT:
                        hit.size = new Vector2(charSize.y / 10, charSize.x / 10);
                        hit.offset = new Vector2(charSize.x / 10, 0);
                        break;
                    case Direction.BOTTOM:
                        hit.size = new Vector2(charSize.y / 10, charSize.x / 10);
                        hit.offset = new Vector2(0, -charSize.y / 10);
                        break;
                    case Direction.LEFT:
                        hit.size = new Vector2(charSize.y / 10, charSize.x / 10);
                        hit.offset = new Vector2(-charSize.x / 10, 0);
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

        if (other.GetComponent<Hittable>() as Hittable != null && hitting)
        {
            switch (GetComponent<MDirection>().Get())
            {
                case Direction.TOP:
                    other.gameObject.transform.Translate(0, knockback, 0);
                    Debug.Log("top");
                    break;
                case Direction.RIGHT:
                    other.gameObject.transform.Translate(knockback, 0, 0);
                    Debug.Log("right");
                    break;
                case Direction.BOTTOM:
                    other.gameObject.transform.Translate(0, -knockback, 0);
                    Debug.Log("bottom");
                    break;
                case Direction.LEFT:
                    other.gameObject.transform.Translate(-knockback, 0, 0);
                    Debug.Log("left");
                    break;
                default:
                    break;
            }
            Destroy(hit);
            hitting = false;
            GetComponent<Animator>().SetBool("isHitting", false);
        }
    }
}
