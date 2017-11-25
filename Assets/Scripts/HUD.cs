using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUi;
    public Player player;
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update ()
    {
        Debug.Log(HeartSprites.Length);
        HeartUi.sprite = HeartSprites[player.getCurrentHealth()];
    }
}
