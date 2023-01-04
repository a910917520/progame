using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStats : MonoBehaviour
{
    [SerializeField] private int level; //�Z������
    [SerializeField] private float damage_multiplier; //�ˮ`���v
    [SerializeField] private int arrow_num; //�b�ڼƶq
    [SerializeField] private bool penetrate; //���L��z
    [SerializeField] private bool hasEffect; //���L�S��ĪG
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
