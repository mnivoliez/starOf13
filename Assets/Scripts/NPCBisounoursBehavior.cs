using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBisounoursBehavior : MonoBehaviour, IInteractable
{

    private FollowPath[] _FollowPaths;

    // Use this for initialization
    void Start()
    {
        _FollowPaths = GetComponentsInParent<FollowPath>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(GameObject player)
    {
        int dialogueNumber = Random.Range(1, 4);

        switch (dialogueNumber)
        {
            case 1:
                GetComponent<Text>().text = "Hey!";
                break;
            case 2:
                GetComponent<Text>().text = "Hey!";
                break;
            case 3:
                GetComponent<Text>().text = "Hey!";
                break;
            case 4:
                GetComponent<Text>().text = "Hey!";
                break;
        }
    }

    void OnDisable()
    {
        
        foreach(FollowPath _FollowPath in _FollowPaths)
        {
            _FollowPath.enabled = false;
        }
    }

    void OnEnable()
    {
        foreach (FollowPath _FollowPath in _FollowPaths)
        {
            _FollowPath.enabled = true;
        }
    }
}
