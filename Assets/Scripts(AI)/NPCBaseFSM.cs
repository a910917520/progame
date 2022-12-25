using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject player;
    public GameObject altar;
    public GameObject waypoint;
    public float rotSpeed = 1;
    public float preDistance = 0.5f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
int layerIndex)
    {
        NPC = animator.gameObject;
        player = NPC.GetComponent<EnemyAI>().GetPlayer();
        altar = NPC.GetComponent<EnemyAI>().GetAltar();
        waypoint = NPC.GetComponent<EnemyAI>().GetWaypoint();
    }
}

