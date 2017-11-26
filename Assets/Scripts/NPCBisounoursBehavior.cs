using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBisounoursBehavior : MonoBehaviour
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

    void OnDisable()
    {
        
        foreach(FollowPath _FollowPath in _FollowPaths)
        {
            _FollowPath.enabled = false;
        }
        GetComponent<NPCTaper>().enabled = true;
        Debug.Log("falsed");
    }

    void OnEnable()
    {
        foreach (FollowPath _FollowPath in _FollowPaths)
        {
            _FollowPath.enabled = true;
        }
        GetComponent<NPCTaper>().enabled = false;
        Debug.Log("trued");
    }
}
