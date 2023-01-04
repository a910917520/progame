using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerController : MonoBehaviour

{

    [SerializeField] Stats stats;





    [SerializeField] private GameObject arrow;

    [SerializeField] private GameObject wind_arrow;

    [SerializeField] private GameObject lightning_arrow;

    [SerializeField] private GameObject fire_arrow;

    [SerializeField] private GameObject ice_arrow;

    [SerializeField] private GameObject spring_arrow;

    [SerializeField] private GameObject summer_arrow;

    [SerializeField] private GameObject autumn_arrow;

    [SerializeField] private GameObject winter_arrow;

    [SerializeField] private GameObject sun_arrow;

    [SerializeField] private GameObject moon_arrow;

    [SerializeField] private GameObject star_arrow;



    [SerializeField] private GameObject arrowPos;

    private float canArrowFire;

    private float canWindArrowFire;

    private float canLightningArrowFire;

    private float canFireArrowFire;

    private float canIceArrowFire;

    private float canSpringArrowFire;

    private float canSummerArrowFire;

    private float canAutumnArrowFire;

    private float canWinterArrowFire;

    private float canSunArrowFire;

    private float canMoonArrowFire;

    private float canStarArrowFire;



    private Animator anim;







    public float fireRate;

    // Start is called before the first frame update

    void Start()

    {

        GameData.Arrow_lv = 0;

        GameData.WindArrow_lv = 0;

        GameData.IceArrow_lv = 0;

        GameData.LightningArrow_lv = 0;

        GameData.SpringArrow_lv = 0;

        GameData.SummerArrow_lv = 0;

        GameData.AutumnArrow_lv = 0;

        GameData.WinterArrow_lv = 0;

        GameData.SunArrow_lv = 0;

        GameData.MoonArrow_lv = 0;

        GameData.StarArrow_lv = 0;

        anim = GetComponent<Animator>();

    }



    // Update is called once per frame

    private void LateUpdate()

    {

        if (Input.GetMouseButton(0))

        {

            anim.SetBool("isAim", true);

        }

        else

        {

            anim.SetBool("isAim", false);

        }

        CheckBow();

    }

    void FixedUpdate()

    {

        fireRate = gameObject.GetComponent<Stats>().GetFireRate();

        PlayerControl();

        if (Input.GetMouseButton(0))

        {

            Attack();

            StartCoroutine(WindAttack());

            FireAttack();

            IceAttack();

            LightningAttack();

            SpringAttack();

            SummerAttack();

            AutumnAttack();

            WinterAttack();

            SunAttack();

            MoonAttack();

            StarAttack();

        }

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

        if (horizontal != 0 || vertical != 0)

        {

            anim.SetBool("isWalk", true);

        }

        else

        {

            anim.SetBool("isWalk", false);

        }



        rd2d.velocity = new Vector3(horizontal, vertical, 0) * stats.speed;

    }

    void Attack()

    {

        if (GameData.Arrow_lv > 0)

        {

            if (Time.time - canArrowFire > 1 / fireRate)

            {

                GameObject arrowObj = Instantiate(arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(1 + GameData.Arrow_lv);

                canArrowFire = Time.time;

            }

        }

    }

    IEnumerator WindAttack()

    {

        if (GameData.WindArrow_lv > 0)

        {

            if (Time.time - canWindArrowFire > 2 / fireRate)

            {

                canWindArrowFire = Time.time;

                float arrowNum = 2 * GameData.WindArrow_lv;

                while (arrowNum > 0)

                {

                    GameObject arrowObj = Instantiate(wind_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                    arrowObj.GetComponent<ArrowStats>().SetMultiplier(1.5f * GameData.WindArrow_lv);

                    arrowNum--;

                    yield return new WaitForSeconds(0.1f);

                }

            }

        }

    }

    void LightningAttack()

    {

        if (GameData.LightningArrow_lv > 0)

        {

            if (Time.time - canLightningArrowFire > 2 / fireRate)

            {

                GameObject arrowObj = Instantiate(lightning_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(1f + 0.5f * (GameData.LightningArrow_lv - 1));

                canLightningArrowFire = Time.time;

            }

        }

    }

    void FireAttack()

    {
        if (GameData.FireArrow_lv > 0)

        {

            if (Time.time - canFireArrowFire > 3 / fireRate)

            {

                GameObject arrowObj = Instantiate(fire_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(1 + GameData.FireArrow_lv);

                canFireArrowFire = Time.time;

            }

        }


    }

    void IceAttack()

    {

        if (GameData.IceArrow_lv > 0)

        {

            if (Time.time - canIceArrowFire > 2 / fireRate)

            {

                Instantiate(ice_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                canIceArrowFire = Time.time;

            }

        }

    }

    void SpringAttack()

    {

        if (GameData.SpringArrow_lv > 0)

        {

            if (Time.time - canSpringArrowFire > (5 - GameData.SpringArrow_lv) / fireRate)

            {

                GameObject arrowObj = Instantiate(spring_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(GameData.SpringArrow_lv);

                canSpringArrowFire = Time.time;

            }

        }

    }

    void SummerAttack()

    {

        if (GameData.SummerArrow_lv > 0)

        {

            if (Time.time - canSummerArrowFire > 3 / fireRate)

            {

                GameObject arrowObj = Instantiate(summer_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(GameData.SummerArrow_lv);

                canSummerArrowFire = Time.time;

            }

        }

    }

    void AutumnAttack()

    {

        if (GameData.AutumnArrow_lv > 0)

        {

            if (Time.time - canAutumnArrowFire > 2 / fireRate)

            {

                if (GameData.AutumnArrow_lv == 1)

                {

                    float angleStep = 40f / 4f;

                    float startAngle = -20f;

                    for (int i = 0; i < 4; i++)

                    {

                        float angle = startAngle + angleStep * i + arrowPos.transform.rotation.eulerAngles.z;

                        GameObject arrowObj = Instantiate(autumn_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                        arrowObj.GetComponent<ArrowMove>().GoDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));

                        arrowObj.GetComponent<ArrowStats>().SetMultiplier(1);

                    }

                }

                if (GameData.AutumnArrow_lv == 2)

                {

                    float angleStep = 60f / 6f;

                    float startAngle = -30f;

                    for (int i = 0; i < 6; i++)

                    {

                        float angle = startAngle + angleStep * i + arrowPos.transform.rotation.eulerAngles.z;

                        GameObject arrowObj = Instantiate(autumn_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                        arrowObj.GetComponent<ArrowMove>().GoDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));

                        arrowObj.GetComponent<ArrowStats>().SetMultiplier(1);

                    }

                }

                if (GameData.AutumnArrow_lv == 3)

                {

                    float angleStep = 60f / 6f;

                    float startAngle = -30f;

                    for (int i = 0; i < 6; i++)

                    {

                        float angle = startAngle + angleStep * i + arrowPos.transform.rotation.eulerAngles.z;

                        GameObject arrowObj = Instantiate(autumn_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                        arrowObj.GetComponent<ArrowMove>().GoDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));

                        arrowObj.GetComponent<ArrowStats>().SetMultiplier(1.5f);

                    }

                }

                if (GameData.AutumnArrow_lv == 4)

                {

                    float angleStep = 80f / 8f;

                    float startAngle = -40f;

                    for (int i = 0; i < 8; i++)

                    {

                        float angle = startAngle + angleStep * i + arrowPos.transform.rotation.eulerAngles.z;

                        GameObject arrowObj = Instantiate(autumn_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                        arrowObj.GetComponent<ArrowMove>().GoDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));

                        arrowObj.GetComponent<ArrowStats>().SetMultiplier(1.5f);

                    }

                }

                canAutumnArrowFire = Time.time;

            }

        }

    }

    void WinterAttack()

    {

        if (GameData.WinterArrow_lv > 0)

        {

            if (Time.time - canWinterArrowFire > 3 / fireRate)

            {

                float arrowNum = 2 + 2 * GameData.WinterArrow_lv;

                float offset = 4 / arrowNum;

                Vector3 startOffset = new Vector3(0, 1.5f, 0);

                while (arrowNum > 0)

                {

                    GameObject arrowObj = Instantiate(winter_arrow, arrowPos.transform.position + startOffset, arrowPos.transform.rotation);

                    arrowObj.GetComponent<ArrowStats>().SetMultiplier(0.5f + GameData.WinterArrow_lv * 0.5f);

                    startOffset = startOffset - new Vector3(0, offset, 0);

                    arrowNum--;

                }

                canWinterArrowFire = Time.time;

            }

        }

    }

    void SunAttack()

    {

        if (GameData.SunArrow_lv > 0)

        {

            if (Time.time - canSunArrowFire > 3 / fireRate)

            {

                float arrowNum = 4 * GameData.SunArrow_lv;

                float angleStep = 360f / arrowNum;

                float startAngle = 0f;

                for (int i = 0; i < arrowNum; i++)

                {

                    float angle = startAngle + angleStep * i + arrowPos.transform.rotation.eulerAngles.z;

                    GameObject arrowObj = Instantiate(sun_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                    arrowObj.GetComponent<ArrowMove>().GoDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));

                    arrowObj.GetComponent<ArrowStats>().SetMultiplier(1);

                }

                canSunArrowFire = Time.time;

            }

        }

    }

    void MoonAttack()

    {

        if (GameData.MoonArrow_lv > 0)

        {

            if (Time.time - canMoonArrowFire > 6 / fireRate)

            {

                GameObject arrowObj = Instantiate(moon_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(1 + GameData.MoonArrow_lv);

                canMoonArrowFire = Time.time;

            }

        }

    }

    void StarAttack()

    {

        if (GameData.StarArrow_lv > 0)

        {

            if (Time.time - canStarArrowFire > 1.3f - GameData.StarArrow_lv * 0.3f / fireRate)

            {

                GameObject arrowObj = Instantiate(star_arrow, arrowPos.transform.position, arrowPos.transform.rotation);

                arrowObj.GetComponent<ArrowStats>().SetMultiplier(0.5f * GameData.StarArrow_lv);

                canStarArrowFire = Time.time;

            }

        }

    }

    void CheckBow()

    {

        if (GameData.Arrow_lv > 0 || GameData.WindArrow_lv > 0 || GameData.FireArrow_lv > 0 || GameData.IceArrow_lv > 0 ||

            GameData.LightningArrow_lv > 0 || GameData.SpringArrow_lv > 0 || GameData.SummerArrow_lv > 0 ||

            GameData.AutumnArrow_lv > 0 || GameData.WinterArrow_lv > 0 || GameData.SunArrow_lv > 0 ||

            GameData.MoonArrow_lv > 0 || GameData.StarArrow_lv > 0)

        {

            anim.SetBool("hasBow", true);

        }

        else

        {

            anim.SetBool("hasBow", false);

        }

    }

}

