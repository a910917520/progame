using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class GameData
{

    //玩家基礎數值
    public static float player_health = 10;
    public static float player_maxHealth = 10;
    public static float player_damage = 10;
    public static float player_fireRate = 1;
    public static float player_speed = 2.5f;

    public static float current_player_health = 10;
    public static float current_player_damage = 10;
    public static float current_player_fireRate = 1;
    public static float current_player_speed = 2.5f;

    public static float damage_bonus = 0; //月之指:基礎攻擊增加1/2/3/4(暫定)
    public static float hp_bonus = 0; //月之髮:基礎生命值增加10/20/30/40(暫定)
    public static float speed_bonus = 0; //月之翼:基礎移動速度增加1/2/3/4(暫定)
    public static float fireRate_bonus = 0; //月之眼:基礎攻速增加10/20/30/40%(暫定)
    //public static float cooldown_bonus = 0; //月之耳:基礎技能冷卻減免增加10/20/30/40%(暫定)

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

