using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject arrow;
    public GameObject wind_arrow;
    public GameObject ice_arrow;
    public GameObject arrowPos;
    private float canArrowFire;
    private float canWindArrowFire;
    private float canIceArrowFire;
    private float canHit;

    //玩家總數值
    public float speed = GameData.player_speed;
    public float fireRate = GameData.player_fireRate;
    public float hitRate = 0.5f;
    public float player_health = GameData.player_health;
    public static float player_damage = GameData.player_damage;
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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd2d.velocity = new Vector3(h, v, 0) * speed;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time - canHit > 1 / hitRate)
            {
                float enemyDamage = collision.GetComponent<EnemyAI>().enemyDamage;
                onHit(enemyDamage);
                canHit = Time.time;
                if (player_health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    public float onHit(float damage)
    {
        player_health = player_health - damage;
        return player_health;
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
