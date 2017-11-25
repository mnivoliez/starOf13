using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taper : MonoBehaviour
{
    bool hitting = false;
    BoxCollider2D hit = null;
    float knockback = 0.3f;
    float knockbackDiago = 0.15f;

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
                Vector2 charSize = GetComponent<Renderer>().bounds.size;

                hit = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                hit.isTrigger = true;

                switch (GetComponent<Direction>().Get())
                {
                    case 1:
                        hit.size = new Vector2(charSize.x, 0.1f);
                        hit.offset = new Vector2(0, charSize.y);
                        break;
                    case 2:
                        hit.size = new Vector2(0.1f, 0.1f);
                        hit.offset = new Vector2(charSize.x, charSize.y);
                        break;
                    case 3:
                        hit.size = new Vector2(0.1f, charSize.y);
                        hit.offset = new Vector2(charSize.x, 0);
                        break;
                    case 4:
                        hit.size = new Vector2(0.1f, 0.1f);
                        hit.offset = new Vector2(charSize.x, -charSize.y);
                        break;
                    case 5:
                        hit.size = new Vector2(charSize.y, 0.1f);
                        hit.offset = new Vector2(0, -charSize.y);
                        break;
                    case 6:
                        hit.size = new Vector2(0.1f, 0.1f);
                        hit.offset = new Vector2(-charSize.x, -charSize.y);
                        break;
                    case 7:
                        hit.size = new Vector2(0.1f, charSize.y);
                        hit.offset = new Vector2(-charSize.x, 0);
                        break;
                    case 8:
                        hit.size = new Vector2(0.1f, 0.1f);
                        hit.offset = new Vector2(-charSize.x, charSize.y);
                        break;
                    default:
                        break;
                }
                
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
            switch (GetComponent<Direction>().Get())
            {
                case 1:
                    other.gameObject.transform.Translate(0, knockback, 0);
                    break;
                case 2:
                    other.gameObject.transform.Translate(knockbackDiago, knockbackDiago, 0);
                    break;
                case 3:
                    other.gameObject.transform.Translate(knockback, 0, 0);
                    break;
                case 4:
                    other.gameObject.transform.Translate(knockbackDiago, -knockbackDiago, 0);
                    break;
                case 5:
                    other.gameObject.transform.Translate(0, -knockback, 0);
                    break;
                case 6:
                    other.gameObject.transform.Translate(-knockbackDiago, -knockbackDiago, 0);
                    break;
                case 7:
                    other.gameObject.transform.Translate(-knockback, 0, 0);
                    break;
                case 8:
                    other.gameObject.transform.Translate(-knockbackDiago, knockbackDiago, 0);
                    break;
                default:
                    break;
            }
            Destroy(hit);
            hitting = false;
        }
    }
}
