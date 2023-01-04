using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStats : MonoBehaviour
{
    [SerializeField] private int level; //武器等級
    [SerializeField] private float damage_multiplier; //傷害倍率
    [SerializeField] private int arrow_num; //箭矢數量
    [SerializeField] private bool penetrate; //有無穿透
    [SerializeField] private bool hasEffect; //有無特殊效果
    [SerializeField] private enum effects {poison,slow,explosion,fire};
    [SerializeField] private effects effect;

    public void SetMultiplier(float number)
    {
        damage_multiplier = number;
    }
    public float GetMultiplier()
    {
        return damage_multiplier;
    }
    public bool IsPenetrate()
    {
        return penetrate;
    }
    public bool IsEffect()
    {
        return hasEffect;
    }
    public int FindEffect()
    {
        return (int)effect;
    }
}
