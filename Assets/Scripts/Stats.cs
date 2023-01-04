using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private float damage;
    [SerializeField] public float speed;
    [SerializeField] private float score;
    [SerializeField] private float hitRate;
    [SerializeField] private float fireRate;
    private float canHit;
    private bool isPoison;
    private bool isSlow;
    [SerializeField] private bool isAltar;

    private void Awake()
    {
        maxHp = hp;
    }
    private void Start()
    {
        if (isAltar)
        {
            StartCoroutine(AltarAttack());
        }
    }
    private void Update()
    {
        if (this.gameObject.tag == ("Player"))
        {
            GameData.UpdataStats(out maxHp,out damage,out speed,out fireRate);
        }
        FixHealth();
    }
    public float GetDamage()
    {
        return damage;
    }
    private void TakeDamage(float damage)
    {
        hp -= damage;
    }
    private float Hit(float hp)
    {
        hp = hp - damage;
        return hp;
    }
    private void GetHit(float hp)
    {
        this.hp = hp;
    }
    public void GetHealthGUI(out float hp,out float maxHp)
    {
        hp = this.hp;
        maxHp = this.maxHp;
    }
    private void GetScore(float score)
    {
        this.score += score;
    }
    public void ScoreGUI(out float score)
    {
        score = this.score;
    }
    public void Heal()
    {
        hp = maxHp;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    private void FixHealth()
    {
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp < 0)
        {
            hp = 0;
        }
    }
    public float GetScore()
    {
        return score;
    }
    public void CostScore(float cost)
    {
        score = score - cost;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Player" || this.gameObject.tag == "Altar")
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
                            Invoke("ReviveOrDie", 3f);
                        }
                    }
                }
                else
                {
                    GetHit(collision.GetComponent<Stats>().Hit(hp));
                    if (hp <= 0)
                    {
                        gameObject.SetActive(false);
                        Invoke("ReviveOrDie", 3f);
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
                            float multiplier = collision.gameObject.GetComponent<ArrowStats>().GetMultiplier();
                            float playerDamage = GameObject.Find("Player").GetComponent<Stats>().GetDamage();
                            float finalDamage = playerDamage * multiplier;
                            //½b¥Ú¶Ë®`
                            TakeDamage(finalDamage);
                            canHit = Time.time;
                            if (collision.gameObject.GetComponent<ArrowStats>().IsEffect())
                            {
                                if (hp > 0)
                                {
                                    if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 0 && !isPoison)
                                    {
                                        StartCoroutine(Poison(finalDamage));
                                    }
                                    if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 1 && !isSlow)
                                    {
                                        StartCoroutine(Slow(GameData.IceArrow_lv));
                                    }
                                }
                                if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 2)
                                {
                                    Explosion(collision.gameObject, finalDamage* 0.5f + (GameData.SummerArrow_lv - 1));
                                }
                            }
                            if (!collision.gameObject.GetComponent<ArrowStats>().IsPenetrate())
                            {
                                Destroy(collision.gameObject);
                            }
                            if (hp <= 0)
                            {
                                GameObject.Find("Player").GetComponent<Stats>().GetScore(score);
                                gameObject.SetActive(false);
                                Invoke("DestoryObject", 2f);
                            }
                        }
                    }
                }
                else
                {
                    float multiplier = collision.gameObject.GetComponent<ArrowStats>().GetMultiplier();
                    float playerDamage = GameObject.Find("Player").GetComponent<Stats>().GetDamage();
                    float finalDamage = playerDamage * multiplier;
                    Debug.Log("Deal " + finalDamage + " damage.");
                    //½b¥Ú¶Ë®`
                    TakeDamage(finalDamage);
                    if (collision.gameObject.GetComponent<ArrowStats>().IsEffect())
                    {
                        if (hp > 0)
                        {
                            if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 0 && !isPoison)
                            {
                                StartCoroutine(Poison(finalDamage));
                            }
                            if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 1 && !isSlow)
                            {
                                StartCoroutine(Slow(GameData.IceArrow_lv));
                            }
                        }
                        if (collision.gameObject.GetComponent<ArrowStats>().FindEffect() == 2)
                        {
                            Explosion(collision.gameObject, finalDamage * (0.5f + (GameData.SummerArrow_lv - 1)));
                        }
                    }
                    if (!collision.gameObject.GetComponent<ArrowStats>().IsPenetrate())
                    {
                        Destroy(collision.gameObject);
                    }

                    if (hp <= 0)
                    {
                        GameObject.Find("Player").GetComponent<Stats>().GetScore(score);
                        gameObject.SetActive(false);
                        Invoke("DestroyObject", 2f);
                    }
                }
        }
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    IEnumerator Poison(float damage)
    {
        while (hp > 0)
        {
            hp -= damage;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Slow(float time)
    {
        float originSpeed = speed;
        speed = speed * 0.5f;
        yield return new WaitForSeconds(time);
        speed = originSpeed;
    }
    void Explosion(GameObject arrow, float damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(arrow.transform.position, 1.6f);
        foreach(Collider2D enemy in colliders)
        {
            if (enemy.tag == ("Enemy"))
            {
                enemy.GetComponent<Stats>().TakeDamage(damage);
                if (enemy.GetComponent<Stats>().hp <= 0)
                {
                    enemy.gameObject.SetActive(false);
                    enemy.GetComponent<Stats>().Invoke("DestroyObject", 2f);
                }
            }
        }
    }
    void ReviveOrDie()
    {
        if (score >= 1000)
        {
            score = score - 1000;
            transform.position = new Vector2(-18, -0.3f);
            gameObject.SetActive(true);
            hp = maxHp;
        }
        if (score < 1000)
        {
            //GameOver
        }
    }
    IEnumerator AltarAttack()
    {

        do
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.transform.position, 1.6f);
            foreach (Collider2D enemy in colliders)
            {
                if (enemy.tag == ("Enemy"))
                {
                    enemy.GetComponent<Stats>().TakeDamage(30);
                    if (enemy.GetComponent<Stats>().hp <= 0)
                    {
                        enemy.gameObject.SetActive(false);
                        enemy.GetComponent<Stats>().Invoke("DestroyObject", 2f);
                    }
                }
            }
            yield return new WaitForSeconds(3f);
        } while (gameObject.activeSelf);
    }
}
