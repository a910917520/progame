using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    [SerializeField] private PopupWindow popup;
    public void OpenChest(string methodName)
    {
        if (!isOpen)
        {
            
            float playerScore = GameObject.Find("Player").GetComponent<Stats>().GetScore();
            if (methodName == "GetItem")
            {
                if (GameData.item1_lv >= 4 && GameData.item2_lv >= 4 && GameData.item3_lv >= 4 && GameData.item4_lv >= 4)
                {
                    popup.AddToQueue("��O�w�F�W��");
                }
                else if (playerScore >= 50)
                {
                    GameObject.Find("Player").GetComponent<Stats>().CostScore(50);
                    Invoke(methodName, 2f);
                    isOpen = true;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    popup.AddToQueue("��������");
                }
            }
            if (methodName == "GetWeapon")
            {
                if (playerScore >= 20)
                {
                    GameObject.Find("Player").GetComponent<Stats>().CostScore(20);
                    Invoke(methodName, 2f);
                    isOpen = true;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    popup.AddToQueue("��������");
                }
            }

        }
    }
    public void GetItem()
    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        int item = Random.Range(1, 5);
        if (item == 1) //�뤧��
        {
            if (GameData.item1_lv < 4)
            {
                GameData.item1_lv++;
                GameData.damage_bonus = GameData.item1_lv + 2;
                GameData.Updata();
                popup.AddToQueue("��o �뤧�� Lv." + GameData.item1_lv);
            }
            else
            {
                popup.AddToQueue("���Ťw��");
            }
        }
        if (item == 2) //�뤧�v
        {
            if (GameData.item2_lv < 4)
            {
                GameData.item2_lv++;
                GameData.hp_bonus = GameData.hp_bonus + 10;
                GameData.Updata();
                popup.AddToQueue("��o �뤧�v Lv." + GameData.item2_lv);
            }
            else
            {
                popup.AddToQueue("���Ťw��");
            }
        }
        if (item == 3) //�뤧�l
        {
            if (GameData.item3_lv < 4)
            {
                GameData.item3_lv++;
                GameData.speed_bonus = GameData.speed_bonus + 1;
                GameData.Updata();
                popup.AddToQueue("��o �뤧�l Lv." + GameData.item3_lv);
            }
            else
            {
                popup.AddToQueue("���Ťw��");
            }
        }
        if (item == 4) //�뤧��
        {
            if (GameData.item4_lv < 4)
            {
                GameData.item4_lv++;
                GameData.fireRate_bonus = GameData.fireRate_bonus + 0.1f;
                GameData.Updata();
                popup.AddToQueue("��o �뤧�� Lv." + GameData.item4_lv);
            }
            else
            {
                popup.AddToQueue("���Ťw��");
            }
        }
        /*if (item == 5) //�뤧��
        {
            if (GameData.item2_lv <= 4)
            {
                GameData.item2_lv++;
                GameData.cooldown_bonus = GameData.cooldown_bonus + 10;
                GameData.Updata();
                popup.AddToQueue("��o" + item + "(Lv." + GameData.item5_lv + ")");
            }
        }*/
    }
    public void GetWeapon()

    {
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        int weapon = Random.Range(1, 13);

        if (weapon == 1) //���F����
        {
            if (GameData.Arrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {
                    GameData.weaponNum++;

                    GameData.Arrow_lv++;
                    popup.AddToQueue("��o���F����");
                }

            }
            else if (GameData.Arrow_lv < 4)

            {

                GameData.Arrow_lv++;
                popup.AddToQueue("��o���F����(Lv." + GameData.Arrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(���F����)�w�F�̰���");

            }
        }

        if (weapon == 2) //�����b��
        {
            if (GameData.WindArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.WindArrow_lv++;
                    popup.AddToQueue("��o�����b��");
                }

            }
            else if (GameData.WindArrow_lv < 4)

            {

                GameData.WindArrow_lv++;

                popup.AddToQueue("��o�����b��(Lv." + GameData.WindArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�����b��)�w�F�̰���");

            }
        }

        if (weapon == 3) //�p���b��
        {
            if (GameData.LightningArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.LightningArrow_lv++;
                    popup.AddToQueue("��o�p���b��");
                }

            }
            else if (GameData.LightningArrow_lv < 4)

            {

                GameData.LightningArrow_lv++;

                popup.AddToQueue("��o�p���b��(Lv." + GameData.LightningArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�p���b��)�w�F�̰���");

            }
        }

        if (weapon == 4) //�����b��
        {
            if (GameData.FireArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.FireArrow_lv++;
                    popup.AddToQueue("��o�����b��");
                }

            }
            else if (GameData.FireArrow_lv < 4)

            {

                GameData.FireArrow_lv++;

                popup.AddToQueue("��o�����b��(Lv." + GameData.FireArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�����b��)�w�F�̰���");

            }
        }

        if (weapon == 5) //�B���b��
        {
            if (GameData.IceArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.IceArrow_lv++;
                    popup.AddToQueue("��o�B���b��");
                }

            }
            else if (GameData.IceArrow_lv < 4)

            {

                GameData.IceArrow_lv++;

                popup.AddToQueue("��o�B���b��(Lv." + GameData.IceArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�B���b��)�w�F�̰���");

            }
        }

        if (weapon == 6) //�K���b��
        {
            if (GameData.SpringArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SpringArrow_lv++;
                    popup.AddToQueue("��o�K���b");
                }

            }
            else if (GameData.SpringArrow_lv < 4)

            {

                GameData.SpringArrow_lv++;

                popup.AddToQueue("��o�K���b(Lv." + GameData.SpringArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�K���b)�w�F�̰���");

            }
        }

        if (weapon == 7) //�L���b��
        {
            if (GameData.SummerArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SummerArrow_lv++;
                    popup.AddToQueue("��o�L���b");
                }

            }
            else if (GameData.SummerArrow_lv < 4)

            {

                GameData.SummerArrow_lv++;

                popup.AddToQueue("��o�L���b(Lv." + GameData.SummerArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�L���b)�w�F�̰���");

            }
        }

        if (weapon == 8) //��b��
        {
            if (GameData.AutumnArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.AutumnArrow_lv++;
                    popup.AddToQueue("��o��b");
                }

            }
            else if (GameData.AutumnArrow_lv < 4)

            {

                GameData.AutumnArrow_lv++;

                popup.AddToQueue("��o��b(Lv." + GameData.AutumnArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(��b)�w�F�̰���");

            }
        }

        if (weapon == 9) //�V���b��
        {
            if (GameData.WinterArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.WinterArrow_lv++;
                    popup.AddToQueue("��o�V���b");
                }

            }
            else if (GameData.WinterArrow_lv < 4)

            {

                GameData.WinterArrow_lv++;

                popup.AddToQueue("��o�V���b(Lv." + GameData.WinterArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�V���b)�w�F�̰���");

            }
        }

        if (weapon == 10) //�餧�b��
        {
            if (GameData.SunArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.SunArrow_lv++;
                    popup.AddToQueue("��o�餧�b");
                }

            }
            else if (GameData.SunArrow_lv < 4)

            {

                GameData.SunArrow_lv++;

                popup.AddToQueue("��o�餧�b(Lv." + GameData.SunArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�餧�b)�w�F�̰���");

            }
        }

        if (weapon == 11) //�뤧�b��
        {
            if (GameData.MoonArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.MoonArrow_lv++;
                    popup.AddToQueue("��o�뤧�b");
                }

            }
            else if (GameData.MoonArrow_lv < 4)

            {

                GameData.MoonArrow_lv++;

                popup.AddToQueue("��o�뤧�b(Lv." + GameData.MoonArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�뤧�b)�w�F�̰���");

            }
        }

        if (weapon == 12) //�P���b��
        {
            if (GameData.StarArrow_lv == 0)

            {

                if (GameData.weaponNum >= 4)

                {

                    popup.AddToQueue("�j�ƥ���");

                }

                else

                {

                    GameData.weaponNum++;

                    GameData.StarArrow_lv++;
                    popup.AddToQueue("��o�P���b");
                }

            }
            else if (GameData.StarArrow_lv < 4)

            {

                GameData.StarArrow_lv++;

                popup.AddToQueue("��o�P���b(Lv." + GameData.StarArrow_lv + ")");

            }
            else

            {

                popup.AddToQueue("�Z��(�P���b)�w�F�̰���");

            }
        }
    }
}
