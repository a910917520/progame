using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float damage;
    [SerializeField] public float speed;
    [SerializeField] private float score;
    [SerializeField] private float hitRate;
    private float canHit;
    private float Hit(float hp)
    {
        hp = hp - damage;
        return hp;
    }
    private void GetHit(float hp)
    {
        this.hp = hp;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (hitRate != 0)
                {
                    if (Time.time - canHit > 1 / hitRate)
                    {
                        GetHit(collision.GetComponent<Stats>().Hit(hp));
                        canHit = Time.time;
                        if (hp <= 0)
                        {
                            gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    GetHit(collision.GetComponent<Stats>().Hit(hp));
                    if (hp <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
        else if (this.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Arrow")
                if (hitRate != 0)
                {
                    if (Time.time - canHit > 1 / hitRate)
                    {
                        if (GameObject.Find("Player") != null)
                        {
                            GetHit(GameObject.Find("Player").GetComponent<Stats>().Hit(hp));
                            canHit = Time.time;
                            Destroy(collision.gameObject);
                            if (hp <= 0)
                            {
                                gameObject.SetActive(false);
                            }
                        }
                    }
                }
                else
                {
                    GetHit(GameObject.Find("Player").GetComponent<Stats>().Hit(hp));
                    Destroy(collision.gameObject);
                    if (hp <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                }
        }
    }
}
