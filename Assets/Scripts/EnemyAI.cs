using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject altar;
    private GameObject waypoint;
    private float speed;

    private int currentWP = 0;
    public float preDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.Find("Waypoint");
        speed = gameObject.GetComponent<Stats>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Chase();
    }
    void Chase()
    {
        if (GameObject.Find("Altar") != null)
        {
            if(Vector3.Distance(GameObject.Find("Altar").transform.position, transform.position) < 4)
            {
                Vector3 direction = (GameObject.Find("Altar").transform.position - transform.position).normalized;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //GetComponent<Rigidbody2D>().rotation = angle;
                GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
            }
            else if (GameObject.Find("Player")!=null)
            {
                if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 3)
                {
                    Vector3 direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
                    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //GetComponent<Rigidbody2D>().rotation = angle;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
                    currentWP = 1;
                }
                else if (currentWP == 0 && Vector3.Distance(waypoint.transform.position, transform.position) > preDistance)
                {
                    Vector3 direction = (waypoint.transform.position - transform.position).normalized;
                    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //GetComponent<Rigidbody2D>().rotation = angle;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
                }
                else if (currentWP == 0)
                {
                    currentWP++;
                }
                else if (currentWP == 1 && GameObject.Find("Altar") != null)
                {
                    Vector3 direction = (GameObject.Find("Altar").transform.position - transform.position).normalized;
                    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //GetComponent<Rigidbody2D>().rotation = angle;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
                }
            }
            else if (currentWP == 0 && Vector3.Distance(waypoint.transform.position, transform.position) > preDistance)
            {
                Vector3 direction = (waypoint.transform.position - transform.position).normalized;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //GetComponent<Rigidbody2D>().rotation = angle;
                GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
            }
            else if (currentWP == 0)
            {
                currentWP++;
            }
            else if (currentWP == 1 && GameObject.Find("Altar") != null)
            {
                Vector3 direction = (GameObject.Find("Altar").transform.position - transform.position).normalized;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //GetComponent<Rigidbody2D>().rotation = angle;
                GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * speed;
            }
        }
        
        
    }
}
