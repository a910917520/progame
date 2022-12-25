using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GameData
{
    public static int gameStage = 0;
    public static int score = 0;

    //���a��¦�ƭ�
    public static float player_health = 1000;
    public static float player_maxHealth = 1000;
    public static float player_damage = 10;
    public static float player_fireRate = 5;
    public static float player_speed = 2.5f;

    public static float current_player_health = 1000;
    public static float current_player_damage = 10;
    public static float current_player_fireRate = 5;
    public static float current_player_speed = 2.5f;

    public static float altar_health = 100000;

    public static float damage_bonus = 0; //�뤧��:��¦�����W�[1/2/3/4(�ȩw)
    public static float hp_bonus = 0; //�뤧�v:��¦�ͩR�ȼW�[1/2/3/4(�ȩw)
    public static float speed_bonus = 0; //�뤧�l:��¦���ʳt�׼W�[1/2/3/4(�ȩw)
    public static float fireRate_bonus = 0; //�뤧��:��¦��t�W�[10/20/30/40%(�ȩw)
    public static float cooldown_bonus = 0; //�뤧��:��¦�ޯ�N�o��K�W�[10/20/30/40%(�ȩw)

    public static int item1_lv = 0;
    public static int item2_lv = 0;
    public static int item3_lv = 0;
    public static int item4_lv = 0;
    public static int item5_lv = 0;

    //equipments
    public static bool windArrow = false;
    public static bool iceArrow = false;
    public static void Updata()
    {
        player_maxHealth = player_health + hp_bonus;
        current_player_health = current_player_health + hp_bonus;
        current_player_damage = player_damage + damage_bonus;
        current_player_fireRate = player_fireRate + player_fireRate * fireRate_bonus;
        current_player_speed = player_speed + speed_bonus;
    }
}

