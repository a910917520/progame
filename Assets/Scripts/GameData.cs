using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GameData
{

    //���a��¦�ƭ�
    public static float player_health = 10;
    public static float player_maxHealth = 10;
    public static float player_damage = 10;
    public static float player_fireRate = 1;
    public static float player_speed = 2.5f;

    public static float current_player_health = 10;
    public static float current_player_damage = 10;
    public static float current_player_fireRate = 1;
    public static float current_player_speed = 2.5f;

    public static float damage_bonus = 0; //�뤧��:��¦�����W�[1/2/3/4(�ȩw)
    public static float hp_bonus = 0; //�뤧�v:��¦�ͩR�ȼW�[10/20/30/40(�ȩw)
    public static float speed_bonus = 0; //�뤧�l:��¦���ʳt�׼W�[1/2/3/4(�ȩw)
    public static float fireRate_bonus = 0; //�뤧��:��¦��t�W�[10/20/30/40%(�ȩw)
    //public static float cooldown_bonus = 0; //�뤧��:��¦�ޯ�N�o��K�W�[10/20/30/40%(�ȩw)

    public static int item1_lv = 0;
    public static int item2_lv = 0;
    public static int item3_lv = 0;
    public static int item4_lv = 0;
    //public static int item5_lv = 0;

    public static int weaponNum = 0;

    public static float Arrow_lv = 0;
    public static float WindArrow_lv = 0;
    public static float LightningArrow_lv = 0;
    public static float FireArrow_lv = 0;
    public static float IceArrow_lv = 0;
    public static float SpringArrow_lv = 0;
    public static float SummerArrow_lv = 0;
    public static float AutumnArrow_lv = 0;
    public static float WinterArrow_lv = 0;
    public static float SunArrow_lv = 0;
    public static float MoonArrow_lv = 0;
    public static float StarArrow_lv = 0;


    //equipments
    public static void Updata()
    {
        player_maxHealth = player_health + hp_bonus;
        current_player_health = current_player_health + hp_bonus;
        current_player_damage = player_damage + damage_bonus;
        current_player_fireRate = player_fireRate + player_fireRate * fireRate_bonus;
        current_player_speed = player_speed + speed_bonus;
    }
    public static void UpdataStats(out float maxHp,out float damage,out float speed,out float fireRate)
    {
        maxHp = player_maxHealth;
        damage = current_player_damage;
        speed = current_player_speed;
        fireRate = current_player_fireRate;
    }
}

