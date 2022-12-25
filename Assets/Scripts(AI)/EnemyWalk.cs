using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : NPCBaseFSM
{
    int currentWP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        Vector3 relativePos = altar.transform.position - NPC.transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        NPC.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        NPC.transform.position += NPC.transform.right * speed;
        */
        if (currentWP == 0 && Vector3.Distance(waypoint.transform.position, NPC.transform.position) > preDistance)
        {
            Vector3 direction = (waypoint.transform.position - NPC.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            NPC.GetComponent<Rigidbody2D>().rotation = angle;
            NPC.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * rotSpeed;
        }
        else if (currentWP == 0) 
        {
            currentWP++;
        }
        if (currentWP == 1)
        {
            Vector3 direction = (altar.transform.position - NPC.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            NPC.GetComponent<Rigidbody2D>().rotation = angle;
            NPC.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * rotSpeed;
        }
    }
}
