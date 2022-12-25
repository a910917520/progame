using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        Vector3 relativePos = player.transform.position - NPC.transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        NPC.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        NPC.transform.position += NPC.transform.right * speed;
        */
        Vector3 direction = (player.transform.position - NPC.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        NPC.GetComponent<Rigidbody2D>().rotation = angle;
        NPC.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * rotSpeed;
    }

}
