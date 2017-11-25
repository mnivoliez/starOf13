using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Node[] PathNode;
    public GameObject NPC;
    public float MoveSpeed = 1;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPositionHolder;

    // Use this for initialization
    void Start()
    {
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
    }

    void CheckNode()
    {
        if (CurrentNode < PathNode.Length)
        {
            Timer = 0;
        }
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    void DrawLine()
    {
        for (int i = 0; i < PathNode.Length; i++)
        {
            if (i < PathNode.Length - 1)
            {
                Debug.DrawLine(PathNode[i].transform.position, PathNode[i + 1].transform.position, Color.green);
            }
        }
        Debug.DrawLine(PathNode[0].transform.position, PathNode[PathNode.Length - 1].transform.position, Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        Timer += Time.deltaTime * MoveSpeed;

        if (NPC.transform.position != CurrentPositionHolder)
        {
            NPC.transform.position = Vector3.Lerp(NPC.transform.position, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
            }
            else
            {
                CurrentNode = 0;
            }

            CheckNode();
        }

    }
}
