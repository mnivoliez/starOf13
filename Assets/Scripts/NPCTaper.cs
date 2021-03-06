﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTaper : MonoBehaviour, IPhaseDriven
{

    bool hitting = false;
    BoxCollider2D hit = null;
    float knockback = 1000f;
    public int Timer;
    public int modulus = 40;

    // Use this for initialization
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer++;
        if (hitting)
        {
            if (Timer % modulus == 0)
            {
                Timer = 0;
                Vector2 charSize = GetComponent<Renderer>().bounds.size;
                hit = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                hit.isTrigger = true;
                GetComponent<Animator>().SetBool("isHitting", true);
                switch (GetComponent<MDirection>().Get())
                {
                    case Direction.TOP:
                        hit.size = new Vector2(charSize.x, 0.1f);
                        hit.offset = new Vector2(0, charSize.y);
                        break;
                    case Direction.RIGHT:
                        hit.size = new Vector2(0.1f, charSize.y);
                        hit.offset = new Vector2(charSize.x, 0);
                        break;
                    case Direction.BOTTOM:
                        hit.size = new Vector2(charSize.y, 0.1f);
                        hit.offset = new Vector2(0, -charSize.y);
                        break;
                    case Direction.LEFT:
                        hit.size = new Vector2(0.1f, charSize.y);
                        hit.offset = new Vector2(-charSize.x, 0);
                        break;
                    default:
                        break;
                }
                hitting = true;
            }
        }
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.GetComponent<Hittable>());
        Debug.Log(hitting);
        if (other.GetComponent<Hittable>() != null && Timer == 0)
        {
            Debug.Log("hey");
            /*switch (GetComponent<MDirection>().Get())
            {
                case Direction.TOP:
                    other.gameObject.transform.Translate(0, knockback, 0);
                    break;
                case Direction.RIGHT:
                    other.gameObject.transform.Translate(knockback, 0, 0);
                    break;
                case Direction.BOTTOM:
                    other.gameObject.transform.Translate(0, -knockback, 0);
                    break;
                case Direction.LEFT:
                    other.gameObject.transform.Translate(-knockback, 0, 0);
                    break;
                default:
                    break;
            }*/
            float kbX = (transform.position.x - other.transform.position.x) % 1;
            float kbY = (transform.position.y - other.transform.position.y) % 1;

            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(kbX * knockback, kbY * knockback);


            other.GetComponent<Player>().hit();
            Debug.Log(other.GetComponent<Player>().getCurrentHealth());
            Debug.Log("hit");
        }
    }

    public void EnterPhase(Phase phase)
    {
        switch (phase)
        {
            case Phase.BISOUNOURS:
                hitting = false;
                Destroy(hit);
                break;
            case Phase.FRIDAY_13:
                hitting = true;                
                break;
        }
    }
}
