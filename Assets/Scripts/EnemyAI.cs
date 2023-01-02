using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private GameObject altar;
    private GameObject waypoint;
    private float speed;

    private int currentWP = 0;
    public float preDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        altar = GameObject.Find("Altar");
        waypoint = GameObject.Find("Waypoint");
        speed = gameObject.GetComponent<Stats>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Chase();
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    public GameObject GetAltar()
    {
        return altar;
    }
    public GameObject GetWaypoint()
    {
        return waypoint;
    }
    void Chase()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = angle;
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
        }
        else if (currentWP == 0 && Vector3.Distance(waypoint.transform.position, transform.position) > preDistance)
        {
            Vector3 direction = (waypoint.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = angle;
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
        }
        else if (currentWP == 0)
        {
            currentWP++;
        }
        else if (currentWP == 1)
        {
            Vector3 direction = (altar.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = angle;
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }
}
