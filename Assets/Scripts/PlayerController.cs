using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Stats stats;


    public GameObject arrow;
    public GameObject wind_arrow;
    public GameObject ice_arrow;
    public GameObject arrowPos;
    private float canArrowFire;
    private float canWindArrowFire;
    private float canIceArrowFire;

    //玩家總數值
    

    public float fireRate = GameData.player_fireRate;
    // Start is called before the first frame update
    void Start()
    {
        GameData.windArrow = true;
        GameData.iceArrow = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerControl();
        Attack();
        WindAttack();
        IceAttack();
        PlayerStatus();
    }
    void PlayerControl()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        */
        Rigidbody2D rd2d = GetComponent<Rigidbody2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        /*if (horizontal > 0)
        {
            renderer.flipX = true;
        }
        else if (horizontal < 0)
        {
            renderer.flipX = false;
        }*/
        rd2d.velocity = new Vector3(horizontal, vertical, 0) * stats.speed;
    }
    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - canArrowFire > 1 / fireRate)
            {
                Instantiate(arrow, arrowPos.transform.position, arrowPos.transform.rotation);
                canArrowFire = Time.time;
            }
        }
    }
    void WindAttack()
    {
        if (Input.GetMouseButton(0))
        {
            if (GameData.windArrow)
            {
                if (Time.time - canWindArrowFire > 2 / fireRate)
                {
                    Instantiate(wind_arrow, arrowPos.transform.position + new Vector3(0.1f, 0.1f, 0), arrowPos.transform.rotation);
                    Instantiate(wind_arrow, arrowPos.transform.position - new Vector3(0.1f, 0.1f, 0), arrowPos.transform.rotation);
                    canWindArrowFire = Time.time;
                }
            }
        }
    }
    void IceAttack()
    {
        if (Input.GetMouseButton(0))
        {
            if (GameData.iceArrow)
            {
                if (Time.time - canIceArrowFire > 2 / fireRate)
                {
                    Instantiate(ice_arrow, arrowPos.transform.position, arrowPos.transform.rotation);
                    canIceArrowFire = Time.time;
                }
            }
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    void PlayerStatus()
    {
        //玩家總數值更新
        //speed = GameData.current_player_speed;
        //fireRate = GameData.current_player_fireRate;
        //hitRate = 0.5f;
        //player_health = GameData.current_player_health;
        //player_damage = GameData.current_player_damage;
    }
}
