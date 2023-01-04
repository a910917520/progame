using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public void OpenChest(string methodName)
    {
        if (!isOpen)
        {
            
            float playerScore = GameObject.Find("Player").GetComponent<Stats>().GetScore();
            if (methodName == "GetItem")
            {
                if (playerScore >= 50)
                {
                    GameObject.Find("Player").GetComponent<Stats>().CostScore(50);
                    Invoke(methodName, 2f);
                    isOpen = true;
                    Debug.Log("Chest is now open...");
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    Debug.Log("金錢不足");
                }
            }
            if (methodName == "GetWeapon")
            {
                if (playerScore >= 20)
                {
                    GameObject.Find("Player").GetComponent<Stats>().CostScore(20);
                    Invoke(methodName, 2f);
                    isOpen = true;
                    Debug.Log("Chest is now open...");
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    Debug.Log("金錢不足");
                }
            }

        }
    }
    public void GetItem()
    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        int item = Random.Range(1, 4);
        if (item == 1) //月之指
        {
            if (GameData.item1_lv < 4)
            {
                GameData.item1_lv++;
                GameData.damage_bonus = GameData.damage_bonus + 1;
                GameData.Updata();
                Debug.Log("獲得" + item + "(Lv." + GameData.item1_lv + ")");
            }
        }
        if (item == 2) //月之髮
        {
            if (GameData.item2_lv < 4)
            {
                GameData.item2_lv++;
                GameData.hp_bonus = GameData.hp_bonus + 10;
                GameData.Updata();

                Debug.Log("獲得" + item + "(Lv." + GameData.item2_lv + ")");
            }
        }
        if (item == 3) //月之翼
        {
            if (GameData.item3_lv < 4)
            {
                GameData.item3_lv++;
                GameData.speed_bonus = GameData.speed_bonus + 1;
                GameData.Updata();

                Debug.Log("獲得" + item + "(Lv." + GameData.item3_lv + ")");
            }
        }
        if (item == 4) //月之眼
        {
            if (GameData.item4_lv < 4)
            {
                GameData.item4_lv++;
                GameData.fireRate_bonus = GameData.fireRate_bonus + 0.1f;
                GameData.Updata();

                Debug.Log("獲得" + item + "(Lv." + GameData.item4_lv + ")");
            }
        }
        /*if (item == 5) //月之耳
        {
            if (GameData.item2_lv <= 4)
            {
                GameData.item2_lv++;
                GameData.cooldown_bonus = GameData.cooldown_bonus + 10;
                GameData.Updata();
                Debug.Log("獲得" + item + "(Lv." + GameData.item5_lv + ")");
            }
        }*/
    }
    public void GetWeapon()

    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        int weapon = Random.Range(1, 12);

        if (weapon == 1) //精靈之矢
        {
            if (GameData.Arrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.Arrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.Arrow_lv < 4)

            {

                GameData.Arrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.Arrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 2) //風之箭矢
        {
            if (GameData.WindArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.WindArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.WindArrow_lv < 4)

            {

                GameData.WindArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.WindArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 3) //雷之箭矢
        {
            if (GameData.LightningArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.LightningArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.LightningArrow_lv < 4)

            {

                GameData.LightningArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.LightningArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 4) //火之箭矢
        {
            if (GameData.FireArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.FireArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.FireArrow_lv < 4)

            {

                GameData.FireArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.FireArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 5) //冰之箭矢
        {
            if (GameData.IceArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.IceArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.IceArrow_lv < 4)

            {

                GameData.IceArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.IceArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 6) //春之箭矢
        {
            if (GameData.SpringArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SpringArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.SpringArrow_lv < 4)

            {

                GameData.SpringArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.SpringArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 7) //夏之箭矢
        {
            if (GameData.SummerArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SummerArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.SummerArrow_lv < 4)

            {

                GameData.SummerArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.SummerArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 8) //秋之箭矢
        {
            if (GameData.AutumnArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.AutumnArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.AutumnArrow_lv < 4)

            {

                GameData.AutumnArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.AutumnArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 9) //冬之箭矢
        {
            if (GameData.WinterArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.WinterArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.WinterArrow_lv < 4)

            {

                GameData.WinterArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.WinterArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 10) //日之箭矢
        {
            if (GameData.SunArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SunArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.SunArrow_lv < 4)

            {

                GameData.SunArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.SunArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 11) //月之箭矢
        {
            if (GameData.MoonArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.MoonArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.MoonArrow_lv < 4)

            {

                GameData.MoonArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.MoonArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }

        if (weapon == 12) //星之箭矢
        {
            if (GameData.StarArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    Debug.Log("武器已滿");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.StarArrow_lv++;
                    Debug.Log("獲得" + weapon);
                }

            }
            else if (GameData.StarArrow_lv < 4)

            {

                GameData.StarArrow_lv++;

                Debug.Log("獲得" + weapon + "(Lv." + GameData.StarArrow_lv + ")");

            }
            else

            {

                Debug.Log("武器已達最高級");

            }
        }
    }
}
