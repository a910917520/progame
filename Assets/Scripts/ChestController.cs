using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is now open...");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("GetItem", 2f);
        }
    }
    void GetItem()
    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        int item = Random.Range(1, 4);
        if (item == 1) //月之指
        {
            if (GameData.item1_lv <= 4)
            {
                GameData.item1_lv++;
                GameData.damage_bonus = GameData.damage_bonus + 1;
                GameData.Updata();
                Debug.Log("獲得" + item + "(Lv." + GameData.item1_lv + ")");
            }
        }
        if (item == 2) //月之髮
        {
            if (GameData.item2_lv <= 4)
            {
                GameData.item2_lv++;
                GameData.hp_bonus = GameData.hp_bonus + 10;
                GameData.Updata();

                Debug.Log("獲得" + item + "(Lv." + GameData.item2_lv + ")");
            }
        }
        if (item == 3) //月之翼
        {
            if (GameData.item3_lv <= 4)
            {
                GameData.item3_lv++;
                GameData.speed_bonus = GameData.speed_bonus + 1;
                GameData.Updata();

                Debug.Log("獲得" + item + "(Lv." + GameData.item3_lv + ")");
            }
        }
        if (item == 4) //月之眼
        {
            if (GameData.item4_lv <= 4)
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
}
