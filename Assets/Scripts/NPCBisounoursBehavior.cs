using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBisounoursBehavior : MonoBehaviour, IInteractable {
	// Use this for initialization
	void Start () {
        
    }

	// Update is called once per frame
	void Update () {

	}

    public void Interact(GameObject player)
    {
        if (GetComponent<NPCBisounoursBehavior>().enabled)
        {
            int dialNbr = Random.Range(1, 4);

            switch (dialNbr)
            {
                case 1:
                    GameObject.FindGameObjectWithTag("Dialogue").GetComponent<UnityEngine.UI.Text>().text = "Hey! How are you doing ?";
                    FindObjectOfType<AudioManager>().Play("girl_0");
                    break;
                case 2:
                    GameObject.FindGameObjectWithTag("Dialogue").GetComponent<UnityEngine.UI.Text>().text = "Nice day, isn't it ?";
                    FindObjectOfType<AudioManager>().Play("girl_0");
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("Dialogue").GetComponent<UnityEngine.UI.Text>().text = "Welcome in the best village ever ! :)";
                    FindObjectOfType<AudioManager>().Play("girl_1");
                    break;
            }
        }
    }
}
